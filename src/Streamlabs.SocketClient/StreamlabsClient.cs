using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SocketIOClient;
using SocketIOClient.Transport;
using Streamlabs.SocketClient.Events;
using Streamlabs.SocketClient.Extensions;

namespace Streamlabs.SocketClient;

public sealed class StreamlabsClient : IStreamlabsClient
{
    private readonly SocketIO _client;
    private readonly ILogger<StreamlabsClient> _logger;

    public StreamlabsClient(ILogger<StreamlabsClient> logger, IOptions<StreamlabsOptions> options)
    {
        _logger = logger;

        _client = new SocketIO(
            options.Value.Url,
            new SocketIOOptions
            {
                Transport = TransportProtocol.WebSocket,
                EIO = EngineIO.V3,
                Query = new[] { new KeyValuePair<string, string>("token", options.Value.Token) },
                Reconnection = options.Value.Reconnection
            }
        );

        _client.OnConnected += (_, _) =>
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Streamlabs: WebSocket connected");
            }
        };

        _client.OnDisconnected += (_, _) =>
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Streamlabs: WebSocket disconnected");
            }
        };

        _client.OnError += (_, message) =>
        {
            if (_logger.IsEnabled(LogLevel.Error))
            {
                _logger.LogError("Streamlabs: Error - {Message}", message);
            }
        };

        _client.OnPing += (_, _) =>
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Streamlabs: ping");
            }
        };

        _client.OnPong += (_, time) =>
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Streamlabs: pong - {Time}ms", time.TotalMilliseconds);
            }
        };

        _client.OnReconnectAttempt += (_, attempt) =>
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Streamlabs: Trying to reconnect - {Attempt}", attempt);
            }
        };

        _client.OnReconnected += (_, attempt) =>
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Streamlabs: Reconnected - {Attempt}", attempt);
            }
        };

        _client.OnReconnectError += (_, exception) =>
        {
            if (_logger.IsEnabled(LogLevel.Error))
            {
                _logger.LogError(exception: exception, message: "Streamlabs: Failed to reconnect");
            }
        };

        _client.On("event", OnEventInternal);
    }

    public event EventHandler<string>? OnEventRaw;
    public event EventHandler<StreamlabsEvent>? OnEvent;
    public event EventHandler<DonationEvent>? OnDonation;
    public event EventHandler<DonationDeleteEvent>? OnDonationDelete;

    private void OnEventInternal(SocketIOResponse response)
    {
        string json = response.ToString();

        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("Streamlabs: Event received - {Payload}", json);
        }

        OnEventRaw?.Invoke(this, json);

        IReadOnlyCollection<StreamlabsEvent> streamlabsEvents;
        try
        {
            streamlabsEvents = json.Deserialize();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Streamlabs: Error deserializing event - {Payload}", json);
            return;
        }

        if (streamlabsEvents.Count > 1 && _logger.IsEnabled(LogLevel.Warning))
        {
            _logger.LogWarning(
                "Streamlabs: Multiple events received, normalizing - Count: {Count}",
                streamlabsEvents.Count
            );
        }

        foreach (StreamlabsEvent streamlabsEvent in streamlabsEvents)
        {
            Dispatch(streamlabsEvent);
        }
    }

    private void Dispatch(StreamlabsEvent streamlabsEvent)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation(
                "Streamlabs: Handling event - {{ Type: {Type}, EventId: {EventId} }}",
                streamlabsEvent.GetType().Name,
                streamlabsEvent.EventId
            );
        }

        OnEvent?.Invoke(this, streamlabsEvent);

        switch (streamlabsEvent)
        {
            case DonationEvent donationEvent:
                OnDonation?.Invoke(this, donationEvent);
                break;
            case DonationDeleteEvent donationDeleteEvent:
                OnDonationDelete?.Invoke(this, donationDeleteEvent);
                break;
        }
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public async Task ConnectAsync()
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation("Streamlabs: Connecting...");
        }

        await _client.ConnectAsync();
    }

    public async Task DisconnectAsync()
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            _logger.LogInformation("Streamlabs: Disconnecting...");
        }

        await _client.DisconnectAsync();
    }
}

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
    private readonly ILogger<StreamlabsWorker> _logger;

    public StreamlabsClient(ILogger<StreamlabsWorker> logger, IOptions<StreamlabsOptions> options)
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

    public event EventHandler<IReadOnlyCollection<StreamlabsEvent>>? OnEvent;
    public event EventHandler<string>? OnEventRaw;

    private void OnEventInternal(SocketIOResponse response)
    {
        string json = response.ToString();

        OnEventRaw?.Invoke(this, json);

        try
        {
            IReadOnlyCollection<StreamlabsEvent> streamlabsEvents = json.Deserialize();
            OnEvent?.Invoke(this, streamlabsEvents);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Streamlabs: Error deserializing event - {Event}", json);
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

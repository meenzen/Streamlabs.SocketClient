using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SocketIO.Core;
using SocketIOClient;
using SocketIOClient.Transport;
using Streamlabs.SocketClient.Events;
using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.InternalExtensions;
using Streamlabs.SocketClient.Messages;

namespace Streamlabs.SocketClient;

public sealed class StreamlabsClient : IStreamlabsClient
{
    private readonly SocketIOClient.SocketIO _client;
    private readonly ILogger<StreamlabsClient> _logger;

    public StreamlabsClient(ILogger<StreamlabsClient> logger, IOptions<StreamlabsOptions> options)
    {
        _logger = logger;

        _client = new SocketIOClient.SocketIO(
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
    public event EventHandler<IStreamlabsEvent>? OnEvent;
    public event EventHandler<DonationMessage>? OnDonation;
    public event EventHandler<BitsMessage>? OnBits;
    public event EventHandler<DonationDeleteMessage>? OnDonationDelete;
    public event EventHandler<BitsAlertPlayingMessage>? OnBitsAlertPlaying;
    public event EventHandler<SubscriptionAlertPlayingMessage>? OnSubscriptionAlertPlaying;
    public event EventHandler<FollowMessage>? OnFollow;
    public event EventHandler<RaidMessage>? OnRaid;
    public event EventHandler<RollEndCreditsMessage>? OnRollEndCredits;

    private void OnEventInternal(SocketIOResponse response) => Dispatch(response.ToString());

    public void Dispatch(string json)
    {
        if (_logger.IsEnabled(LogLevel.Debug))
        {
            _logger.LogDebug("Streamlabs: Event received - {Payload}", json);
        }

        OnEventRaw?.Invoke(this, json);

        IReadOnlyCollection<IStreamlabsEvent> streamlabsEvents;
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

        foreach (IStreamlabsEvent streamlabsEvent in streamlabsEvents)
        {
            Dispatch(streamlabsEvent);
        }
    }

    private void Dispatch(IStreamlabsEvent streamlabsEvent)
    {
        if (_logger.IsEnabled(LogLevel.Information))
        {
            string? eventId = (streamlabsEvent as IHasEventId)?.EventId;

            _logger.LogInformation(
                "Streamlabs: Handling event - {{ Type: {Type}, EventId: {EventId} }}",
                streamlabsEvent.GetType().Name,
                eventId
            );
        }

        OnEvent?.Invoke(this, streamlabsEvent);

        switch (streamlabsEvent)
        {
            case DonationEvent donationEvent:
                foreach (DonationMessage message in donationEvent.Messages)
                {
                    OnDonation?.Invoke(this, message);
                }
                break;
            case BitsEvent bitsEvent:
                foreach (BitsMessage message in bitsEvent.Messages)
                {
                    OnBits?.Invoke(this, message);
                }
                break;
            case RaidEvent raidEvent:
                foreach (RaidMessage message in raidEvent.Messages)
                {
                    OnRaid?.Invoke(this, message);
                }
                break;
            case DonationDeleteEvent donationDeleteEvent:
                OnDonationDelete?.Invoke(this, donationDeleteEvent.Message);
                break;
            case FollowEvent followEvent:
                foreach (FollowMessage message in followEvent.Messages)
                {
                    OnFollow?.Invoke(this, message);
                }
                break;
            case RollEndCreditsEvent rollEndCreditsEvent:
                OnRollEndCredits?.Invoke(this, rollEndCreditsEvent.Message);
                break;
            case AlertPlayingEvent alertPlayingEvent:
                switch (alertPlayingEvent.Message)
                {
                    case BitsAlertPlayingMessage bitsAlert:
                        OnBitsAlertPlaying?.Invoke(this, bitsAlert);
                        break;
                    case SubscriptionAlertPlayingMessage subscriptionAlert:
                        OnSubscriptionAlertPlaying?.Invoke(this, subscriptionAlert);
                        break;
                    default:
                        _logger.LogError(
                            "Streamlabs: Unsupported AlertPlayingMessage type - {Type}",
                            alertPlayingEvent.Message.GetType().Name
                        );
                        break;
                }
                break;
            default:
                _logger.LogError("Streamlabs: Unsupported event type - {Type}", streamlabsEvent.GetType().Name);
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

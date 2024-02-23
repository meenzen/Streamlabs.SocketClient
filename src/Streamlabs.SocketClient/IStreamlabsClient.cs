using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages;

namespace Streamlabs.SocketClient;

public interface IStreamlabsClient : IDisposable
{
    /// <summary>
    /// Connects to the Streamlabs websocket API.
    /// </summary>
    Task ConnectAsync();

    /// <summary>
    /// Disconnects from the Streamlabs websocket API.
    /// </summary>
    Task DisconnectAsync();

    /// <summary>
    /// Allows executing the entire event pipeline using a raw json payload.
    /// </summary>
    /// <param name="json">The raw json payload.</param>
    void Dispatch(string json);

    /// <summary>
    /// Fires when a raw json payload is received from the websocket.
    /// </summary>
    event EventHandler<string>? OnEventRaw;

    /// <summary>
    /// Fires for each event contained in the json payload after it has been successfully deserialized.
    /// </summary>
    event EventHandler<IStreamlabsEvent>? OnEvent;

    event EventHandler<DonationMessage>? OnDonation;
    event EventHandler<BitsMessage>? OnBits;
    event EventHandler<DonationDeleteMessage>? OnDonationDelete;
    event EventHandler<BitsAlertPlayingMessage>? OnBitsAlertPlaying;
    event EventHandler<SubscriptionAlertPlayingMessage>? OnSubscriptionAlertPlaying;
    event EventHandler<FollowMessage>? OnFollow;
    event EventHandler<RaidMessage>? OnRaid;
    event EventHandler<RollEndCreditsMessage>? OnRollEndCredits;
    event EventHandler<StreamlabelsMessage>? OnStreamlabels;
    event EventHandler<StreamlabelsUnderlyingMessage>? OnStreamlabelsUnderlying;
    event EventHandler<SubMysteryGiftMessage>? OnSubMysteryGift;
    event EventHandler<SubscriptionMessage>? OnSubscription;
}

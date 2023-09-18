using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages;

namespace Streamlabs.SocketClient;

public interface IStreamlabsClient : IDisposable
{
    Task ConnectAsync();
    Task DisconnectAsync();

    /// <summary>
    /// Allows executing the entire event pipeline using a raw json payload.
    /// </summary>
    /// <param name="json"></param>
    void Dispatch(string json);

    event EventHandler<string>? OnEventRaw;
    event EventHandler<IStreamlabsEvent>? OnEvent;
    event EventHandler<DonationMessage>? OnDonation;
    event EventHandler<BitsMessage>? OnBits;
    event EventHandler<DonationDeleteMessage>? OnDonationDelete;
    event EventHandler<BitsAlertPlayingMessage>? OnBitsAlertPlaying;
    event EventHandler<SubscriptionAlertPlayingMessage>? OnSubscriptionAlertPlaying;
    event EventHandler<FollowMessage>? OnFollow;
}

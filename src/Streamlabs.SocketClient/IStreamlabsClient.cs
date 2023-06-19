using Streamlabs.SocketClient.Events;

namespace Streamlabs.SocketClient;

public interface IStreamlabsClient : IDisposable
{
    Task ConnectAsync();
    Task DisconnectAsync();
    event EventHandler<string>? OnEventRaw;
    event EventHandler<StreamlabsEvent>? OnEvent;
    event EventHandler<DonationEvent>? OnDonation;
    event EventHandler<DonationDeleteEvent>? OnDonationDelete;
}

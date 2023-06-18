using Streamlabs.SocketClient.Events;

namespace Streamlabs.SocketClient;

public interface IStreamlabsClient : IDisposable
{
    Task ConnectAsync();
    Task DisconnectAsync();
    event EventHandler<IReadOnlyCollection<StreamlabsEvent>>? OnEvent;
    event EventHandler<string>? OnEventRaw;
}

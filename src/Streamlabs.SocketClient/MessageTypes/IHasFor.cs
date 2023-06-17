namespace Streamlabs.SocketClient.MessageTypes;

public interface IHasFor
{
    public ServiceType For { get; init; }
}

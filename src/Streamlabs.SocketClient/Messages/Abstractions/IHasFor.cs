using Streamlabs.SocketClient.Messages.DataTypes;

namespace Streamlabs.SocketClient.Messages.Abstractions;

public interface IHasFor
{
    public ServiceType For { get; init; }
}

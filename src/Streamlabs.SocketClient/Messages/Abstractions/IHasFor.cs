using Streamlabs.SocketClient.Messages.DataTypes;

namespace Streamlabs.SocketClient.Messages.Abstractions;

public interface IHasFor
{
    ServiceType For { get; init; }
}

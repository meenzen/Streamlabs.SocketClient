namespace Streamlabs.SocketClient.Messages.Abstractions;

public interface IHasPriority
{
    long Priority { get; init; }
}

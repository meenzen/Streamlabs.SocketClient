namespace Streamlabs.SocketClient.Messages.Abstractions;

public interface IHasMessageId
{
    string MessageId { get; init; }
}

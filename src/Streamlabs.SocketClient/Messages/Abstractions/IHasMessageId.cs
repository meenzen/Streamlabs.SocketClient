namespace Streamlabs.SocketClient.Messages.Abstractions;

public interface IHasMessageId
{
    public string MessageId { get; init; }
}

using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Events.Abstractions;

public interface IHasStreamlabsMessage<TMessage>
    where TMessage : IStreamlabsMessage
{
    public TMessage Message { get; init; }
}

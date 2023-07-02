using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Events.Abstractions;

public interface IHasStreamlabsMessageCollection<TMessage>
    where TMessage : IStreamlabsMessage
{
    IReadOnlyCollection<TMessage> Messages { get; init; }
}

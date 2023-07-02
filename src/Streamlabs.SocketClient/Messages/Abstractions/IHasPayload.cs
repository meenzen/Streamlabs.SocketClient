namespace Streamlabs.SocketClient.Messages.Abstractions;

public interface IHasPayload<TPayload>
    where TPayload : IPayload
{
    TPayload Payload { get; init; }
}

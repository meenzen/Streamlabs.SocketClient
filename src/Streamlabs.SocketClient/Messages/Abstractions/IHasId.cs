namespace Streamlabs.SocketClient.Messages.Abstractions;

public interface IHasId<TId>
    where TId : notnull
{
    TId Id { get; init; }
}

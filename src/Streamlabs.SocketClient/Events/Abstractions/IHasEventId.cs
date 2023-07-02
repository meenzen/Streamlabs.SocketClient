namespace Streamlabs.SocketClient.Events.Abstractions;

public interface IHasEventId
{
    string EventId { get; init; }
}

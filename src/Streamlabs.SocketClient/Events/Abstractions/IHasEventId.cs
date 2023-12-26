namespace Streamlabs.SocketClient.Events.Abstractions;

public interface IHasEventId
{
    /// <summary>
    /// A unique identifier for the event.
    /// </summary>
    /// <example>"evt_1234567890abcdef1234567890abcdef" or "1234567890abcdef1234567890abcdef"</example>
    string EventId { get; init; }
}

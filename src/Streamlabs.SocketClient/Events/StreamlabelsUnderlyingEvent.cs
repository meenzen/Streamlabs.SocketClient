using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages;

namespace Streamlabs.SocketClient.Events;

public sealed record StreamlabelsUnderlyingEvent
    : IStreamlabsEvent,
        IHasStreamlabsMessage<StreamlabelsUnderlyingMessage>,
        IHasEventId
{
    [JsonPropertyName("message")]
    public required StreamlabelsUnderlyingMessage Message { get; init; }

    [JsonPropertyName("event_id")]
    public required string EventId { get; init; }
}

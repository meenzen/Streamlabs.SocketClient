using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages;

namespace Streamlabs.SocketClient.Events;

public sealed record StreamlabelsEvent : IStreamlabsEvent, IHasStreamlabsMessage<StreamlabelsMessage>, IHasEventId
{
    [JsonPropertyName("message")]
    public required StreamlabelsMessage Message { get; init; }

    [JsonPropertyName("event_id")]
    public required string EventId { get; init; }
}

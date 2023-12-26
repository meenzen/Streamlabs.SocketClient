using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages;

namespace Streamlabs.SocketClient.Events;

public sealed record RollEndCreditsEvent : IStreamlabsEvent, IHasStreamlabsMessage<RollEndCreditsMessage>, IHasEventId
{
    [JsonPropertyName("message")]
    public required RollEndCreditsMessage Message { get; init; }

    [JsonPropertyName("event_id")]
    public required string EventId { get; init; }
}

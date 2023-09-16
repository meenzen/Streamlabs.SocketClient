using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Events;

public class FollowEvent : IStreamlabsEvent, IHasStreamlabsMessageCollection<FollowMessage>, IHasEventId
{
    [JsonPropertyName("message")]
    public required IReadOnlyCollection<FollowMessage> Messages { get; init; }

    [JsonPropertyName("for")]
    public required string For { get; init; }

    [JsonPropertyName("event_id")]
    public required string EventId { get; init; }
}

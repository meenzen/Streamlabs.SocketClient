using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages;

namespace Streamlabs.SocketClient.Events;

public sealed record MuteVolumeEvent : IStreamlabsEvent, IHasStreamlabsMessageCollection<MuteVolumeMessage>, IHasEventId
{
    [JsonPropertyName("message")]
    public required IReadOnlyCollection<MuteVolumeMessage> Messages { get; init; }

    [JsonPropertyName("event_id")]
    public required string EventId { get; init; }
}

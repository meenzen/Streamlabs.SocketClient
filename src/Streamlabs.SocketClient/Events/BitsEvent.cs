using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages;

namespace Streamlabs.SocketClient.Events;

public sealed record BitsEvent : IStreamlabsEvent, IHasStreamlabsMessageCollection<BitsMessage>
{
    [JsonPropertyName("message")]
    public required IReadOnlyCollection<BitsMessage> Messages { get; init; }

    [JsonPropertyName("for")]
    public required string For { get; init; }

    [JsonPropertyName("event_id")]
    public string? EventId { get; init; }
}

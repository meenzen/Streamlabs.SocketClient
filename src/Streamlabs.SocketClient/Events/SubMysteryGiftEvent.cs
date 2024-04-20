using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages;

namespace Streamlabs.SocketClient.Events;

public sealed record SubMysteryGiftEvent : IStreamlabsEvent, IHasStreamlabsMessageCollection<SubMysteryGiftMessage>
{
    [JsonPropertyName("message")]
    public required IReadOnlyCollection<SubMysteryGiftMessage> Messages { get; init; }

    [JsonPropertyName("for")]
    public required string For { get; init; }

    [JsonPropertyName("event_id")]
    public string? EventId { get; init; }
}

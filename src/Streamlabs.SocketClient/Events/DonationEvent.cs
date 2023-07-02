using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Events;

public sealed record DonationEvent : IStreamlabsEvent, IHasStreamlabsMessageCollection<DonationMessage>, IHasEventId
{
    [JsonPropertyName("event_id")]
    public required string EventId { get; init; }

    [JsonPropertyName("message")]
    public required IReadOnlyCollection<DonationMessage> Messages { get; init; }
}

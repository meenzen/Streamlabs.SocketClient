using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages;

namespace Streamlabs.SocketClient.Events;

public sealed record DonationDeleteEvent : IStreamlabsEvent, IHasStreamlabsMessage<DonationDeleteMessage>, IHasEventId
{
    [JsonPropertyName("event_id")]
    public required string EventId { get; init; }

    [JsonPropertyName("message")]
    public required DonationDeleteMessage Message { get; init; }
}

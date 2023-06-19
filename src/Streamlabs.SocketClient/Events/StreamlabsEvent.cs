using Streamlabs.SocketClient.Events.Abstractions;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Events;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(DonationEvent), typeDiscriminator: "donation")]
[JsonDerivedType(typeof(DonationDeleteEvent), typeDiscriminator: "donationDelete")]
public record StreamlabsEvent : IHasEventId
{
    [JsonPropertyName("event_id")]
    public required string EventId { get; init; }
}

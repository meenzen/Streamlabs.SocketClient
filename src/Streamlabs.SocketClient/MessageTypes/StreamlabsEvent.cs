using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.MessageTypes;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(DonationEvent), typeDiscriminator: "donation")]
public record StreamlabsEvent
{
    [JsonPropertyName("event_id")]
    public required string EventId { get; init; }
}

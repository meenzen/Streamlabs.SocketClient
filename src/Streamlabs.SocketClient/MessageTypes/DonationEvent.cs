using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.MessageTypes;

public record DonationEvent : StreamlabsEvent
{
    [JsonPropertyName("message")]
    public required IReadOnlyCollection<Donation> Message { get; init; }
}

using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.MessageTypes;

public record DonationDeleteEvent : StreamlabsEvent
{
    [JsonPropertyName("message")]
    public required DonationDelete Message { get; init; }
}

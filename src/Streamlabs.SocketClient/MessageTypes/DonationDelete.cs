using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.MessageTypes;

public record DonationDelete : IStreamlabsMessage, IHasId
{
    [JsonPropertyName("id")]
    public required long Id { get; init; }
}

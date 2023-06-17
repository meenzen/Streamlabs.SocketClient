using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.MessageTypes;

public record StreamlabsMessage
{
    [JsonPropertyName("_id")]
    public required string MessageId { get; init; }
}

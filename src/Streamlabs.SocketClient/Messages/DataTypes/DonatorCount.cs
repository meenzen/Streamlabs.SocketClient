using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public sealed record DonatorCount
{
    [JsonPropertyName("count")]
    public required long Count { get; init; }
}

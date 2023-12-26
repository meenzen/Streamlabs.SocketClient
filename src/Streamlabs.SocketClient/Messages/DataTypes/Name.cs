using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public sealed record Name
{
    [JsonPropertyName("name")]
    public required string Value { get; init; }
}

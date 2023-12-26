using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public sealed record Amount
{
    [JsonPropertyName("amount")]
    public required int Value { get; init; }
}

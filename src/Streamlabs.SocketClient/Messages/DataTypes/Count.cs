using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Converters;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public sealed record Count
{
    [JsonPropertyName("count")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int Value { get; init; }
}

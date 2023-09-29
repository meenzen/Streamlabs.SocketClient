using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public sealed record LabeledCollection<T>
{
    [JsonPropertyName("label")]
    public required string Label { get; init; }

    [JsonPropertyName("values")]
    public required IReadOnlyCollection<T> Values { get; init; }
}

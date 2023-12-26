using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public sealed record Counter : IHasName
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("count")]
    public required long Value { get; init; }
}

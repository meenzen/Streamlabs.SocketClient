using Streamlabs.SocketClient.Messages.Abstractions;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public sealed record Recipient : IHasName
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }
}

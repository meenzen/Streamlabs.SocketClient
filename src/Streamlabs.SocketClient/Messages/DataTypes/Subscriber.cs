using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public sealed record Subscriber : IHasName
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("months")]
    public required int Months { get; init; }
}

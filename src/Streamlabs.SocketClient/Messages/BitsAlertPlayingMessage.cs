using Streamlabs.SocketClient.Messages.Abstractions;
using Streamlabs.SocketClient.Messages.DataTypes;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages;

public sealed record BitsAlertPlayingMessage : AlertPlayingMessage, IHasPayload<EmptyPayload>
{
    [JsonPropertyName("currency")]
    public required string Currency { get; init; }

    [JsonPropertyName("payload")]
    public required EmptyPayload Payload { get; init; }

    [JsonPropertyName("style")]
    public required string Style { get; init; }
}

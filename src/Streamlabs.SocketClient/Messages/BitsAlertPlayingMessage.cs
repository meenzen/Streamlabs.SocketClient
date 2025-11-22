using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Messages.Abstractions;
using Streamlabs.SocketClient.Messages.DataTypes;

namespace Streamlabs.SocketClient.Messages;

public sealed record BitsAlertPlayingMessage : AlertPlayingMessage, IHasPayload<BitsAlertPayload>
{
    [JsonPropertyName("currency")]
    public required string Currency { get; init; }

    [JsonPropertyName("payload")]
    public required BitsAlertPayload Payload { get; init; }

    [JsonPropertyName("style")]
    public required string Style { get; init; }

    [JsonPropertyName("isPreview")]
    public bool? IsPreview { get; init; }
}

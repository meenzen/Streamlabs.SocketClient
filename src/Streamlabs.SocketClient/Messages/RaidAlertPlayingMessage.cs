using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Converters;
using Streamlabs.SocketClient.Messages.Abstractions;
using Streamlabs.SocketClient.Messages.DataTypes;

namespace Streamlabs.SocketClient.Messages;

public sealed record RaidAlertPlayingMessage : AlertPlayingMessage, IHasPayload<EmptyPayload>
{
    [JsonPropertyName("raiders")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int Raiders { get; init; }

    [JsonPropertyName("payload")]
    public required EmptyPayload Payload { get; init; }

    [JsonPropertyName("count")]
    public required int Count { get; init; }
}

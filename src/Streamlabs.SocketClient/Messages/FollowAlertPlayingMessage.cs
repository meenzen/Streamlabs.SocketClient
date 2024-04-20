using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Messages.Abstractions;
using Streamlabs.SocketClient.Messages.DataTypes;

namespace Streamlabs.SocketClient.Messages;

public sealed record FollowAlertPlayingMessage : AlertPlayingMessage, IHasPayload<FollowAlertPayload>
{
    [JsonPropertyName("to")]
    public required string To { get; init; }

    [JsonPropertyName("payload")]
    public required FollowAlertPayload Payload { get; init; }

    [JsonPropertyName("wotcCode")]
    public string? WotcCode { get; init; }
}

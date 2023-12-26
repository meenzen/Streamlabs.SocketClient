using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Messages.Abstractions;
using Streamlabs.SocketClient.Messages.DataTypes;

namespace Streamlabs.SocketClient.Messages;

public sealed record StreamlabelsUnderlyingMessage : IStreamlabsMessage
{
    [JsonPropertyName("hash")]
    public required string Hash { get; init; }

    [JsonPropertyName("data")]
    public required StreamlabelsUnderlyingMessageData Data { get; init; }
}

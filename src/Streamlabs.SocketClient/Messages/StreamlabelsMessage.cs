using Streamlabs.SocketClient.Messages.Abstractions;
using Streamlabs.SocketClient.Messages.DataTypes;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages;

public sealed record StreamlabelsMessage : IStreamlabsMessage
{
    [JsonPropertyName("hash")]
    public required string Hash { get; init; }

    [JsonPropertyName("data")]
    public required StreamlabelsMessageData Data { get; init; }
}

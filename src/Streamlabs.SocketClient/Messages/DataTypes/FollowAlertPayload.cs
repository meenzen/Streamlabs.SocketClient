using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public sealed record FollowAlertPayload : IPayload, IHasMessageId, IHasName, IHasPriority
{
    [JsonPropertyName("_id")]
    public required string MessageId { get; init; }

    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("priority")]
    public required long Priority { get; init; }
}

using Streamlabs.SocketClient.Messages.Abstractions;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages;

public sealed record FollowMessage : IStreamlabsMessage, IHasId<long>, IHasMessageId, IHasName, IHasPriority
{
    [JsonPropertyName("id")]
    public required long Id { get; init; }

    [JsonPropertyName("_id")]
    public required string MessageId { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("priority")]
    public required long Priority { get; init; }
}

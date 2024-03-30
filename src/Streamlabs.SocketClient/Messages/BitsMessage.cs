using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Messages;

public sealed record BitsMessage
    : IStreamlabsMessage,
        IHasId<string>,
        IHasName,
        IHasDisplayName,
        IHasAmount<int>,
        IHasEmotes,
        IHasMessage,
        IHasMessageId
{
    /// <summary>
    /// This id is a UUID sometimes. Other times it is just a random string. No idea why.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("display_name")]
    public required string DisplayName { get; init; }

    [JsonPropertyName("amount")]
    public required int Amount { get; init; }

    [JsonPropertyName("emotes")]
    public required string? Emotes { get; init; }

    [JsonPropertyName("message")]
    public required string Message { get; init; }

    [JsonPropertyName("_id")]
    public required string MessageId { get; init; }

    [JsonPropertyName("event_id")]
    [Obsolete("Use MessageId instead.")]
    public string EventId { get; init; } = string.Empty;

    [JsonPropertyName("priority")]
    public long? Priority { get; init; }
}

using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Messages;

public sealed record BitsMessage
    : IStreamlabsMessage,
        IHasId<Guid>,
        IHasName,
        IHasDisplayName,
        IHasAmount<int>,
        IHasEmotes,
        IHasMessage,
        IHasMessageId
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

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
}

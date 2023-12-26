using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Converters;
using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Messages;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(SubscriptionAlertPlayingMessage), typeDiscriminator: "subscription")]
[JsonDerivedType(typeof(BitsAlertPlayingMessage), typeDiscriminator: "bits")]
public record AlertPlayingMessage
    : IStreamlabsMessage,
        IHasPriority,
        IHasMessageId,
        IHasFrom,
        IHasEmotes,
        IHasMessage,
        IHasName,
        IHasDisplayName
{
    [JsonPropertyName("priority")]
    public required long Priority { get; init; }

    [JsonPropertyName("_id")]
    public required string MessageId { get; init; }

    [JsonPropertyName("from")]
    public required string From { get; init; }

    [JsonPropertyName("from_display_name")]
    public required string FromDisplayName { get; init; }

    [JsonPropertyName("emotes")]
    public required string? Emotes { get; init; }

    [JsonPropertyName("message")]
    public required string Message { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("display_name")]
    public required string DisplayName { get; init; }

    [JsonPropertyName("repeat")]
    public required bool Repeat { get; init; }

    [JsonPropertyName("isTest")]
    public required bool IsTest { get; init; }

    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; init; }

    /// <summary>
    /// Unix timestamp in milliseconds.
    /// </summary>
    [JsonPropertyName("createdAtTimestamp")]
    [JsonConverter(typeof(UnixTimestampConverter))]
    public required DateTimeOffset CreatedAtTimestamp { get; init; }

    // todo: find out why using the ServiceType enum doesn't work
    [JsonPropertyName("platform")]
    public required string Platform { get; init; }

    [JsonPropertyName("amount")]
    public int? Amount { get; init; }

    [JsonPropertyName("read")]
    public bool Read { get; init; }

    /// <summary>
    /// Badly implemented "hash" field of the payload. Collisions are very likely.
    /// <br/><br/>
    /// Format: "&lt;type&gt;:&lt;name&gt;:&lt;message&gt;"
    /// <br/><br/>
    /// Example: "subscription:test_user:This is a test message"
    /// </summary>
    [JsonPropertyName("hash")]
    public required string Hash { get; init; }
}

using Streamlabs.SocketClient.Messages.Abstractions;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages;

public sealed record RaidMessage : IStreamlabsMessage, IHasId<Guid>, IHasName, IHasDisplayName
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    /// <summary>
    /// The name of the channel that was raided.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// The display name of the channel that was raided.
    /// </summary>
    [JsonPropertyName("display_name")]
    public required string DisplayName { get; init; }

    /// <summary>
    /// The number of viewers participating in the raid.
    /// </summary>
    [JsonPropertyName("raiders")]
    public required int Raiders { get; init; }

    [JsonPropertyName("_id")]
    public required Guid MessageId { get; init; }

    [JsonPropertyName("event_id")]
    public required Guid EventId { get; init; }
}

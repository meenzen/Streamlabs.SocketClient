using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Messages;

public sealed record SubscriptionMessage : IStreamlabsMessage, IHasName, IHasDisplayName, IHasEmotes, IHasMessageId
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("display_name")]
    public required string DisplayName { get; init; }

    [JsonPropertyName("months")]
    public required int Months { get; init; }

    [JsonPropertyName("message")]
    public required string? Message { get; init; }

    [JsonPropertyName("emotes")]
    public required string? Emotes { get; init; }

    /// <summary>
    /// The sub plan.
    /// </summary>
    /// <example>1000</example>
    [JsonPropertyName("sub_plan")]
    public required string SubPlan { get; init; }

    [JsonPropertyName("sub_plan_name")]
    public required string SubPlanName { get; init; }

    /// <summary>
    /// The type of subscription.
    /// </summary>
    /// <example>"subgift"</example>
    [JsonPropertyName("sub_type")]
    public required string SubType { get; init; }

    /// <summary>
    /// The lowercase username of the gifter.
    /// </summary>
    [JsonPropertyName("gifter")]
    public required string? Gifter { get; init; }

    [JsonPropertyName("gifter_display_name")]
    public string? GifterDisplayName { get; init; }

    [JsonPropertyName("streak_months")]
    public int? StreakMonths { get; init; }

    [JsonPropertyName("gifter_twitch_id")]
    public long? GifterTwitchId { get; init; }

    [JsonPropertyName("subscriber_twitch_id")]
    public long? SubscriberTwitchId { get; init; }

    [JsonPropertyName("_id")]
    public required string MessageId { get; init; }

    [JsonPropertyName("event_id")]
    [Obsolete("Use MessageId instead.")]
    public string EventId { get; init; } = string.Empty;
}

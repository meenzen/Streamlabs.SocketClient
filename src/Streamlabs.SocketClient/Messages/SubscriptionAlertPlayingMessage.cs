using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Messages.Abstractions;
using Streamlabs.SocketClient.Messages.DataTypes;

namespace Streamlabs.SocketClient.Messages;

public sealed record SubscriptionAlertPlayingMessage : AlertPlayingMessage, IHasPayload<AlertPayload>
{
    [JsonPropertyName("months")]
    public required int Months { get; init; }

    [JsonPropertyName("streak_months")]
    public required int? StreakMonths { get; init; }

    [JsonPropertyName("payload")]
    public required AlertPayload Payload { get; init; }

    [JsonPropertyName("subPlan")]
    [Obsolete("Use SubPlan instead.")]
    public string SubPlanLegacy { get; init; } = string.Empty;

    [JsonPropertyName("sub_plan")]
    public required string SubPlan { get; init; }

    [JsonPropertyName("subscriber_twitch_id")]
    public required string? SubscriberTwitchId { get; init; }

    [JsonPropertyName("gifter")]
    public required string Gifter { get; init; }

    [JsonPropertyName("gifter_display_name")]
    public required string? GifterDisplayName { get; init; }

    [JsonPropertyName("count")]
    public required int Count { get; init; }

    [JsonPropertyName("planName")]
    [Obsolete("Always empty. Use Payload.SubPlanName instead.")]
    public string PlanNameLegacy { get; init; } = string.Empty;

    [JsonPropertyName("sub_type")]
    public SubType SubType { get; init; }

    [JsonPropertyName("membershipLevel")]
    public string? MembershipLevel { get; init; }

    [JsonPropertyName("membershipLevelName")]
    public string? MembershipLevelName { get; init; }

    [JsonPropertyName("membershipGift")]
    public string? MembershipGift { get; init; }

    [JsonPropertyName("membershipGiftMessageId")]
    public string? MembershipGiftMessageId { get; init; }

    [JsonPropertyName("massSubGiftChildAlerts")]
    public IReadOnlyList<SubscriptionAlertPlayingMessage>? MassSubGiftChildAlerts { get; init; }

    [JsonPropertyName("isSubgiftExpanded")]
    public bool IsSubgiftExpanded { get; init; }

    [JsonPropertyName("benefit_end_month")]
    public string? BenefitEndMonth { get; init; }
}

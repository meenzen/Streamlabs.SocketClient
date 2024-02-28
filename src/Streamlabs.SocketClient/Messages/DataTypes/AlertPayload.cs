using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public sealed record AlertPayload
    : IPayload,
        IHasName,
        IHasDisplayName,
        IHasMessage,
        IHasEmotes,
        IHasMessageId,
        IHasEventId
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("display_name")]
    public required string DisplayName { get; init; }

    [JsonPropertyName("months")]
    public required int Months { get; init; }

    [JsonPropertyName("message")]
    public required string Message { get; init; }

    [JsonPropertyName("emotes")]
    public required string? Emotes { get; init; }

    [JsonPropertyName("sub_plan")]
    public required string SubPlan { get; init; }

    [JsonPropertyName("sub_plan_name")]
    public required string SubPlanName { get; init; }

    [JsonPropertyName("sub_type")]
    public required SubType SubType { get; init; }

    [JsonPropertyName("gifter")]
    public required string? Gifter { get; init; }

    [JsonPropertyName("gifter_display_name")]
    public string? GifterDisplayName { get; init; }

    [JsonPropertyName("gifter_twitch_id")]
    public string? GifterTwitchId { get; init; }

    [JsonPropertyName("subscriber_twitch_id")]
    public required string SubscriberTwitchId { get; init; }

    [JsonPropertyName("streak_months")]
    public required int? StreakMonths { get; init; }

    [JsonPropertyName("_id")]
    public required string MessageId { get; init; }

    [JsonPropertyName("event_id")]
    public required string EventId { get; init; }
}

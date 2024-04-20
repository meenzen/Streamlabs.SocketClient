using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Messages;

public sealed record SubMysteryGiftMessage : IStreamlabsMessage, IHasName, IHasAmount<int>, IHasMessageId
{
    /// <summary>
    /// The sub plan.
    /// </summary>
    /// <example>1000</example>
    [JsonPropertyName("sub_plan")]
    public required int SubPlan { get; init; }

    [JsonPropertyName("subPlan")]
    [Obsolete("Use SubPlan instead.")]
    public int? SubPlanDuplicate { get; init; }

    /// <summary>
    /// The type of subscription.
    /// </summary>
    /// <example>"submysterygift"</example>
    [JsonPropertyName("sub_type")]
    public required string SubType { get; init; }

    /// <summary>
    /// The lowercase username of the gifter.
    /// </summary>
    [JsonPropertyName("gifter")]
    public required string Gifter { get; init; }

    [Obsolete("Use Name instead.")]
    [JsonPropertyName("gifter_display_name")]
    public string GifterDisplayName { get; init; } = string.Empty;

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("amount")]
    public required int Amount { get; init; }

    [JsonPropertyName("_id")]
    public required string MessageId { get; init; }

    [JsonPropertyName("event_id")]
    [Obsolete("Use MessageId instead.")]
    public string EventId { get; init; } = string.Empty;

    [JsonPropertyName("priority")]
    public long? Priority { get; init; }
}

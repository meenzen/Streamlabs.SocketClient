using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public sealed record SubMysteryGiftPayload : IPayload, IHasName, IHasMessageId, IHasEventId
{
    [JsonPropertyName("sub_plan")]
    public required string SubPlan { get; init; }

    [JsonPropertyName("sub_type")]
    public required SubType SubType { get; init; }

    [JsonPropertyName("gifter")]
    public required string? Gifter { get; init; }

    [JsonPropertyName("gifter_display_name")]
    public required string? GifterDisplayName { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("amount")]
    public required int Months { get; init; }

    [JsonPropertyName("_id")]
    public required string MessageId { get; init; }

    [JsonPropertyName("event_id")]
    public required string EventId { get; init; }
}

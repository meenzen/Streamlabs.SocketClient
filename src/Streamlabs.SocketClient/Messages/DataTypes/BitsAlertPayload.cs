using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Converters;
using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public sealed record BitsAlertPayload : IPayload
{
    [JsonPropertyName("_id")]
    public string? MessageId { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("event_id")]
    public string? EventId { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    [JsonPropertyName("amount")]
    [JsonConverter(typeof(IntStringConverter))]
    public int? Amount { get; init; }

    [JsonPropertyName("emotes")]
    public string? Emotes { get; init; }

    [JsonPropertyName("message")]
    public string? Message { get; init; }
}

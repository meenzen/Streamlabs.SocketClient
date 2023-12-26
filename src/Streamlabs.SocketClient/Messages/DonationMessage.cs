using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Messages.Abstractions;
using Streamlabs.SocketClient.Messages.DataTypes;

namespace Streamlabs.SocketClient.Messages;

public sealed record DonationMessage
    : IStreamlabsMessage,
        IHasId<long>,
        IHasName,
        IHasAmount<decimal>,
        IHasMessage,
        IHasFrom,
        IHasMessageId,
        IHasPriority
{
    [JsonPropertyName("id")]
    public required long Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("amount")]
    public required decimal Amount { get; init; }

    [JsonPropertyName("formatted_amount")]
    public required string FormattedAmount { get; init; }

    [JsonPropertyName("formattedAmount")]
    [Obsolete("Use FormattedAmount instead.")]
    public string FormattedAmountLegacy { get; init; } = string.Empty;

    [JsonPropertyName("message")]
    public required string Message { get; init; }

    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    [JsonPropertyName("emotes")]
    public required string? Emotes { get; init; }

    [JsonPropertyName("iconClassName")]
    public required string IconClassName { get; init; }

    [JsonPropertyName("to")]
    public required Recipient To { get; init; }

    [JsonPropertyName("from")]
    public required string From { get; init; }

    [JsonPropertyName("from_user_id")]
    public required string? FromUserId { get; init; }

    [JsonPropertyName("donation_currency")]
    [Obsolete("Use Currency instead.")]
    public Currency DonationCurrency { get; init; }

    [JsonPropertyName("source")]
    public required string? Source { get; init; }

    [JsonPropertyName("_id")]
    public required string MessageId { get; init; }

    [JsonPropertyName("priority")]
    public required long Priority { get; init; }
}

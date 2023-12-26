using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public record DonationAmount
{
    /// <summary>
    /// The amount that was donated
    /// </summary>
    /// <example>"$13.37"</example>
    [JsonPropertyName("amount")]
    public required string Amount { get; init; }
}

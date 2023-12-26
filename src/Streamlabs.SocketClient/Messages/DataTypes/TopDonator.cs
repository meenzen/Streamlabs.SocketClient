using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public sealed record TopDonator : IHasName
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// The amount that was donated
    /// </summary>
    /// <example>"$13.37"</example>
    [JsonPropertyName("amount")]
    public required string Amount { get; init; }
}

using Streamlabs.SocketClient.Messages.Abstractions;
using Streamlabs.SocketClient.Messages.DataTypes;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages;

public sealed record RollEndCreditsMessage : IStreamlabsMessage
{
    [JsonPropertyName("types")]
    public required RollEndCreditsPayload Payload { get; init; }

    [JsonPropertyName("credit_title")]
    [Obsolete("Use Settings.CreditTitle instead")]
    public string CreditTitle { get; init; } = string.Empty;

    [JsonPropertyName("credit_subtitle")]
    [Obsolete("Use Settings.CreditSubTitle instead")]
    public string CreditSubTitle { get; init; } = string.Empty;

    [JsonPropertyName("settings")]
    public required RollEndCreditsSettings Settings { get; init; }
}

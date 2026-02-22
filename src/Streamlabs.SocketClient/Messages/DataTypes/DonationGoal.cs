using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public sealed record DonationGoal
{
    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [JsonPropertyName("currentAmount")]
    public required string CurrentAmount { get; init; }

    [JsonPropertyName("goalAmount")]
    public required string GoalAmount { get; init; }
}

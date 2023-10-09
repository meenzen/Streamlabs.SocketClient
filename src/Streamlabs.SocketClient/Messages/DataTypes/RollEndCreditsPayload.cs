using Streamlabs.SocketClient.Messages.Abstractions;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public sealed record RollEndCreditsPayload : IHasMessageId, IHasPriority
{
    /// <summary>
    /// A list of users that donated
    /// </summary>
    [JsonPropertyName("donations")]
    public LabeledCollection<string>? Donations { get; init; }

    /// <summary>
    /// A list of users that used bits
    /// </summary>
    [JsonPropertyName("bits")]
    public LabeledCollection<string>? Bits { get; init; }

    /// <summary>
    /// A list of users that are moderators
    /// </summary>
    [JsonPropertyName("moderators")]
    public LabeledCollection<string>? Moderators { get; init; }

    /// <summary>
    /// A list of users that followed
    /// </summary>
    [JsonPropertyName("followers")]
    public LabeledCollection<string>? Followers { get; init; }

    /// <summary>
    /// A list of users that subscribed or resubscribed
    /// </summary>
    [JsonPropertyName("subscribers")]
    public LabeledCollection<string>? Subscribers { get; init; }

    /// <summary>
    /// A list of channels that raided
    /// </summary>
    public LabeledCollection<string>? Raids { get; init; }

    /// <summary>
    /// A list of channels that hosted
    /// </summary>
    public LabeledCollection<string>? Hosts { get; init; }

    [JsonPropertyName("_id")]
    public required string MessageId { get; init; }

    [JsonPropertyName("priority")]
    public required long Priority { get; init; }
}

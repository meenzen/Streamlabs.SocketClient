using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages;

namespace Streamlabs.SocketClient.Events;

public sealed record RaidEvent : IStreamlabsEvent, IHasStreamlabsMessageCollection<RaidMessage>
{
    [JsonPropertyName("message")]
    public required IReadOnlyCollection<RaidMessage> Messages { get; init; }

    [JsonPropertyName("for")]
    public required string For { get; init; }
}

using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages;

namespace Streamlabs.SocketClient.Events;

public sealed record SubscriptionEvent : IStreamlabsEvent, IHasStreamlabsMessageCollection<SubscriptionMessage>
{
    [JsonPropertyName("message")]
    public required IReadOnlyCollection<SubscriptionMessage> Messages { get; init; }

    [JsonPropertyName("for")]
    public required string For { get; init; }
}

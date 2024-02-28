using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages;

namespace Streamlabs.SocketClient.Events;

public sealed record SubscriptionPlayingEvent : IStreamlabsEvent, IHasStreamlabsMessage<AlertPlayingMessage>
{
    [JsonPropertyName("message")]
    public required AlertPlayingMessage Message { get; init; }
}

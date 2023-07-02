using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Events;

public sealed record AlertPlayingEvent : IStreamlabsEvent, IHasStreamlabsMessage<AlertPlayingMessage>
{
    [JsonPropertyName("message")]
    public required AlertPlayingMessage Message { get; init; }
}

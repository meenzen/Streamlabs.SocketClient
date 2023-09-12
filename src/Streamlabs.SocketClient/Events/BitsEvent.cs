using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages;
using Streamlabs.SocketClient.Messages.DataTypes;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Events;

public sealed record BitsEvent : IStreamlabsEvent, IHasStreamlabsMessageCollection<BitsMessage>
{
    [JsonPropertyName("message")]
    public required IReadOnlyCollection<BitsMessage> Messages { get; init; }

    /// <summary>
    /// This property is part of the base event instead of the message for some reason.
    /// Whoever designed this API should be ashamed of themselves.
    /// </summary>
    [JsonPropertyName("for")]
    public required string For { get; init; }
}

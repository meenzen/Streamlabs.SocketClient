using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages;
using Streamlabs.SocketClient.Messages.DataTypes;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Events;

public sealed record BitsEvent : IStreamlabsEvent, IHasStreamlabsMessageCollection<BitsMessage>
{
    [JsonPropertyName("message")]
    public required IReadOnlyCollection<BitsMessage> Messages { get; init; }

    [JsonPropertyName("for")]
    public required string For { get; init; }
}
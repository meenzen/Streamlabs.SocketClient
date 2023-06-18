using Streamlabs.SocketClient.Messages;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Events;

public sealed record DonationEvent : StreamlabsEvent
{
    [JsonPropertyName("message")]
    public required IReadOnlyCollection<DonationMessage> Messages { get; init; }
}

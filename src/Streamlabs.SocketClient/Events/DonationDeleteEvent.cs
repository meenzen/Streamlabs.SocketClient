using Streamlabs.SocketClient.Messages;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Events;

public sealed record DonationDeleteEvent : StreamlabsEvent
{
    [JsonPropertyName("message")]
    public required DonationDeleteMessage Message { get; init; }
}

using Streamlabs.SocketClient.Events.Abstractions;
using Streamlabs.SocketClient.Messages;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Events;

public sealed record DonationDeleteEvent : StreamlabsEvent, IHasStreamlabsMessage<DonationDeleteMessage>
{
    [JsonPropertyName("message")]
    public required DonationDeleteMessage Message { get; init; }
}

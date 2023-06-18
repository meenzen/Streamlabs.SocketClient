using Streamlabs.SocketClient.Messages.Abstractions;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages;

public sealed record DonationDeleteMessage : IStreamlabsMessage, IHasId
{
    [JsonPropertyName("id")]
    public required long Id { get; init; }
}

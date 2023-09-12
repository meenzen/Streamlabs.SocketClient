using Streamlabs.SocketClient.Messages.Abstractions;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages;

public sealed record DonationDeleteMessage : IStreamlabsMessage, IHasId<long>
{
    [JsonPropertyName("id")]
    public required long Id { get; init; }
}

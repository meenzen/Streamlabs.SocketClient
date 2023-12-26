using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Messages;

public sealed record DonationDeleteMessage : IStreamlabsMessage, IHasId<long>
{
    [JsonPropertyName("id")]
    public required long Id { get; init; }
}

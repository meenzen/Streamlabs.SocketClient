using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.MessageTypes;

public interface IHasMessage
{
    public string Message { get; init; }
}

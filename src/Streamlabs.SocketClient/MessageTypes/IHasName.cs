using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.MessageTypes;

public interface IHasName
{
    public string Name { get; init; }
}

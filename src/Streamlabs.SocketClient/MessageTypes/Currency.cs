using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.MessageTypes;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Currency
{
    Usd
}

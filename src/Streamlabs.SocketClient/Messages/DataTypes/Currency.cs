using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages.DataTypes;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Currency
{
    Usd,
}

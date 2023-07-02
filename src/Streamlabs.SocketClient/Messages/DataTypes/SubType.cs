using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages.DataTypes;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubType
{
    [EnumMember(Value = "resub")]
    Resub,

    [EnumMember(Value = "subgift")]
    SubGift,
}

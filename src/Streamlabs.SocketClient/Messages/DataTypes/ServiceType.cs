using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages.DataTypes;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ServiceType
{
    [EnumMember(Value = "streamlabs")]
    Streamlabs,

    [EnumMember(Value = "twitch_account")]
    TwitchAccount,

    [EnumMember(Value = "youtube_account")]
    YouTubeAccount,

    [EnumMember(Value = "mixer_account")]
    [Obsolete("Mixer does not exist anymore, but it is still listed as an option in the Streamlabs documentation.")]
    MixerAccount,
}

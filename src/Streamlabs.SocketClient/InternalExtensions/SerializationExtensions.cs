using System.Text.Json;
using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Events.Abstractions;

namespace Streamlabs.SocketClient.InternalExtensions;

internal static class SerializationExtensions
{
    private static readonly JsonSerializerOptions Options = new()
    {
        AllowTrailingCommas = false,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
    };

    private static readonly IReadOnlyCollection<IStreamlabsEvent> Empty = [];

    public static IReadOnlyCollection<IStreamlabsEvent> Deserialize(this string json)
    {
        string normalized = json.NormalizeTypeDiscriminators();
        return JsonSerializer.Deserialize<IReadOnlyCollection<IStreamlabsEvent>>(normalized, Options) ?? Empty;
    }

    public static bool IsJsonObjectOrArray(this string value)
    {
        string trimmed = value.Trim();
        return trimmed switch
        {
            "" => false,
            ['{', .., '}'] => true,
            ['[', .., ']'] => true,
            _ => false,
        };
    }
}

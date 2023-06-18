using Streamlabs.SocketClient.MessageTypes;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient;

public static class Serializer
{
    private static readonly JsonSerializerOptions Options =
        new() { AllowTrailingCommas = false, NumberHandling = JsonNumberHandling.AllowReadingFromString };

    private static readonly IReadOnlyCollection<StreamlabsEvent> Empty = Array.Empty<StreamlabsEvent>();

    public static IReadOnlyCollection<StreamlabsEvent> Deserialize(this string json)
    {
        return JsonSerializer.Deserialize<IReadOnlyCollection<StreamlabsEvent>>(json, Options) ?? Empty;
    }
}

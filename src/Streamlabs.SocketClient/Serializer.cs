using Streamlabs.SocketClient.MessageTypes;
using System.Text.Json;

namespace Streamlabs.SocketClient;

public static class Serializer
{
    private static readonly JsonSerializerOptions Options = new JsonSerializerOptions { AllowTrailingCommas = false };

    private static readonly IReadOnlyCollection<StreamlabsEvent> Empty = Array.Empty<StreamlabsEvent>();

    public static IReadOnlyCollection<StreamlabsEvent> Deserialize(this string json)
    {
        return JsonSerializer.Deserialize<IReadOnlyCollection<StreamlabsEvent>>(json, Options) ?? Empty;
    }
}

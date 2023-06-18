using Streamlabs.SocketClient.Events;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Extensions;

internal static class SerializationExtensions
{
    private static readonly JsonSerializerOptions Options =
        new() { AllowTrailingCommas = false, NumberHandling = JsonNumberHandling.AllowReadingFromString };

    private static readonly IReadOnlyCollection<StreamlabsEvent> Empty = Array.Empty<StreamlabsEvent>();

    public static IReadOnlyCollection<StreamlabsEvent> Deserialize(this string json)
    {
        return JsonSerializer.Deserialize<IReadOnlyCollection<StreamlabsEvent>>(json, Options) ?? Empty;
    }
}

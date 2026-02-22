using System.Text.Json;
using System.Text.Json.Serialization;
using Streamlabs.SocketClient.InternalExtensions;

namespace Streamlabs.SocketClient.Converters;

/// <summary>
/// Provides a flexible JSON converter for <typeparamref name="T"/> that handles mixed input types.
/// This converter can deserialize <typeparamref name="T"/> from a standard JSON object,
/// an escaped JSON string (double-encoded), or gracefully handle plain non-JSON strings by returning null.
/// </summary>
/// <typeparam name="T">The reference type to deserialize into.</typeparam>
public class FlexibleObjectConverter<T> : JsonConverter<T>
    where T : class
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType switch
        {
            JsonTokenType.StartObject => JsonSerializer.Deserialize<T>(ref reader, options),
            JsonTokenType.StartArray => JsonSerializer.Deserialize<T>(ref reader, options),
            JsonTokenType.String => DeserializeString(ref reader, options),
            _ => null,
        };

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);

    private static T? DeserializeString(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        string? value = reader.GetString();
        if (value is null)
        {
            return null;
        }

        if (!value.IsJsonObjectOrArray())
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T>(value.Trim(), options);
        }
        catch (JsonException)
        {
            return null;
        }
    }
}

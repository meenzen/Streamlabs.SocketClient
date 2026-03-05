using System.Text.Json;
using System.Text.Json.Serialization;
using Streamlabs.SocketClient.InternalExtensions;

namespace Streamlabs.SocketClient.Converters;

/// <summary>
/// Provides a flexible JSON converter for <typeparamref name="T"/> (struct) that handles mixed input types.
/// This converter can deserialize <typeparamref name="T"/> from a standard JSON object,
/// an escaped JSON string (double-encoded), or gracefully handle plain non-JSON strings by returning null.
/// </summary>
/// <typeparam name="T">The value type to deserialize into.</typeparam>
public class FlexibleStructConverter<T> : JsonConverter<T?>
    where T : struct
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.TokenType switch
        {
            JsonTokenType.StartObject => JsonSerializer.Deserialize<T>(ref reader, options),
            JsonTokenType.StartArray => JsonSerializer.Deserialize<T>(ref reader, options),
            JsonTokenType.String => DeserializeString(ref reader, options),
            JsonTokenType.Number => JsonSerializer.Deserialize<T>(ref reader, options),
            _ => null,
        };

    public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options) =>
        JsonSerializer.Serialize(writer, value, options);

    private static T? DeserializeString(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        string? value = reader.GetString();
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        if (typeof(T) == typeof(int) && int.TryParse(value, out var intValue))
        {
            return intValue as T?;
        }

        if (typeof(T) == typeof(long) && long.TryParse(value, out var longValue))
        {
            return longValue as T?;
        }

        if (typeof(T) == typeof(float) && float.TryParse(value, out var floatValue))
        {
            return floatValue as T?;
        }

        if (typeof(T) == typeof(double) && double.TryParse(value, out var doubleValue))
        {
            return doubleValue as T?;
        }

        if (typeof(T) == typeof(decimal) && decimal.TryParse(value, out var decimalValue))
        {
            return decimalValue as T?;
        }

        if (!value!.IsJsonObjectOrArray())
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T>(value!.Trim(), options);
        }
        catch (JsonException)
        {
            return null;
        }
    }
}

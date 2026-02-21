using System.Text.Json;
using System.Text.Json.Serialization;

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
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.StartObject or JsonTokenType.StartArray:
                return JsonSerializer.Deserialize<T>(ref reader, options);
            case JsonTokenType.String:
            {
                string? value = reader.GetString();
                if (value == null)
                {
                    return null;
                }

                string trimmed = value.Trim();

                bool isJsonObject = trimmed.Length > 0 && trimmed[0] == '{' && trimmed[^1] == '}';
                bool isJsonArray = trimmed.Length > 0 && trimmed[0] == '[' && trimmed[^1] == ']';

                if (isJsonObject || isJsonArray)
                {
                    try
                    {
                        return JsonSerializer.Deserialize<T>(trimmed, options);
                    }
                    catch (JsonException)
                    {
                        return null;
                    }
                }

                break;
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Converters;

public class EmptyStringToNullConverter<T> : JsonConverter<T>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert switch
        {
            _ when typeToConvert == typeof(T) => true,
            not null when typeToConvert == typeof(string) => true,
            _ => false,
        };
    }

    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return default;
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            return default;
        }

        return JsonSerializer.Deserialize<T>(ref reader, options);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}

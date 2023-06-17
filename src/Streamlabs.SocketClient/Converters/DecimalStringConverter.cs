using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Converters;

public class DecimalStringConverter : JsonConverter<decimal>
{
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                return decimal.Parse(
                    reader.GetString() ?? throw new ArgumentNullException(nameof(reader), "Reader string is null"),
                    CultureInfo.InvariantCulture
                );
            default:
                throw new ArgumentOutOfRangeException(nameof(reader), "Reader token type is not a string");
        }
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
}

using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Converters;

/// <summary>
/// Converts strings with thousands separators to integers.
/// </summary>
internal sealed class IntStringConverter : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return int.Parse(
            reader.GetString() ?? throw new InvalidOperationException("String is null"),
            NumberStyles.AllowThousands,
            CultureInfo.InvariantCulture
        );
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}

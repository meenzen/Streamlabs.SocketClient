// Adapted from: https://github.com/microsoft/PowerApps-Language-Tooling/blob/master/src/PAModel/Utility/JsonNormalizer.cs
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Streamlabs.SocketClient.InternalExtensions;

internal static class JsonNormalizationExtensions
{
    private sealed class TypeDiscriminatorFirstComparer : IComparer<string>
    {
        private const string TypeDiscriminator = "type";

        public int Compare(string? x, string? y)
        {
            if (x == TypeDiscriminator)
            {
                return -1;
            }

            if (y == TypeDiscriminator)
            {
                return 1;
            }

            return 0;
        }
    }

    private static readonly JsonWriterOptions Options = new() { Indented = true, Encoder = JavaScriptEncoder.Default };
    private static readonly IComparer<string> Comparer = new TypeDiscriminatorFirstComparer();

    internal static string NormalizeTypeDiscriminators(this string json)
    {
        using JsonDocument doc = JsonDocument.Parse(json);
        return doc.RootElement.NormalizeTypeDiscriminators();
    }

    private static string NormalizeTypeDiscriminators(this JsonElement jsonElement)
    {
        using var stream = new MemoryStream();
        using (var writer = new Utf8JsonWriter(stream, Options))
        {
            jsonElement.Write(writer);
        }

        byte[] bytes = stream.ToArray();
        return Encoding.UTF8.GetString(bytes);
    }

    private static void Write(this JsonElement jsonElement, Utf8JsonWriter writer)
    {
        switch (jsonElement.ValueKind)
        {
            case JsonValueKind.Object:
                writer.WriteStartObject();

                // Here we force the type discriminator to be the first property in the object.
                foreach (
                    JsonProperty property in jsonElement.EnumerateObject().OrderBy(property => property.Name, Comparer)
                )
                {
                    writer.WritePropertyName(property.Name);
                    property.Value.Write(writer);
                }

                writer.WriteEndObject();
                break;

            case JsonValueKind.Array:
                writer.WriteStartArray();

                foreach (JsonElement element in jsonElement.EnumerateArray())
                {
                    element.Write(writer);
                }

                writer.WriteEndArray();
                break;

            case JsonValueKind.Number:
                writer.WriteNumberValue(jsonElement.GetDouble());
                break;

            case JsonValueKind.String:
                writer.WriteStringValue(jsonElement.GetString());
                break;

            case JsonValueKind.Null:
                writer.WriteNullValue();
                break;

            case JsonValueKind.True:
                writer.WriteBooleanValue(true);
                break;

            case JsonValueKind.False:
                writer.WriteBooleanValue(false);
                break;

            default:
                throw new NotImplementedException($"JsonElement ValueKind: {jsonElement.ValueKind}");
        }
    }
}

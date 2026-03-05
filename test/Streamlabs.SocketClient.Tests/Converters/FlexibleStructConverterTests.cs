using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Converters;

namespace Streamlabs.SocketClient.Tests.Converters;

[SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods")]
public class FlexibleStructConverterTests
{
    private sealed class SampleClass
    {
        [JsonConverter(typeof(FlexibleStructConverter<SamplePayload>))]
        public SamplePayload? Payload { get; set; }
    }

    private sealed class SampleClass2
    {
        [JsonConverter(typeof(FlexibleStructConverter<int>))]
        public int? Value { get; set; }
    }

    private struct SamplePayload
    {
        public string? Name { get; set; }
        public int Count { get; set; }
    }

    [Test]
    public async Task Read_ObjectToken_Deserializes()
    {
        // Arrange
        var json = """{"Payload":{"Name":"Alpha","Count":3}}""";

        // Act
        var result = JsonSerializer.Deserialize<SampleClass>(json);

        // Assert
        await Assert.That(result).IsNotNull();
        await Assert.That(result.Payload).IsNotNull();
        await Assert.That(result.Payload!.Value.Name).IsEqualTo("Alpha");
        await Assert.That(result.Payload.Value.Count).IsEqualTo(3);
    }

    [Test]
    public async Task Read_EscapedJsonString_Deserializes()
    {
        // Arrange
        var json = """{"Payload":"{\"Name\":\"Beta\",\"Count\":7}"}""";

        // Act
        var result = JsonSerializer.Deserialize<SampleClass>(json);

        // Assert
        await Assert.That(result).IsNotNull();
        await Assert.That(result.Payload).IsNotNull();
        await Assert.That(result.Payload!.Value.Name).IsEqualTo("Beta");
        await Assert.That(result.Payload.Value.Count).IsEqualTo(7);
    }

    [Test]
    public async Task Read_PlainString_ReturnsNull()
    {
        // Arrange
        var json = """{"Payload":"just a plain string"}""";

        // Act
        var result = JsonSerializer.Deserialize<SampleClass>(json);

        // Assert
        await Assert.That(result).IsNotNull();
        await Assert.That(result!.Payload).IsNull();
    }

    [Test]
    public async Task Read_MalformedJsonString_ReturnsNull()
    {
        // Arrange
        var json = """{"Payload":"{not valid json}"}""";

        // Act
        var result = JsonSerializer.Deserialize<SampleClass>(json);

        // Assert
        await Assert.That(result).IsNotNull();
        await Assert.That(result!.Payload).IsNull();
    }

    [Test]
    public async Task Write_SerializesNormally()
    {
        // Arrange
        SampleClass sample = new()
        {
            Payload = new SamplePayload { Name = "Gamma", Count = 42 },
        };

        // Act
        var json = JsonSerializer.Serialize(sample);

        // Assert
        await Assert.That(json).Contains("\"Payload\"");
        await Assert.That(json).Contains("\"Name\":\"Gamma\"");
        await Assert.That(json).Contains("\"Count\":42");
    }

    [Test]
    [Arguments("""{"Value":123}""", 123)]
    [Arguments("""{"Value":"123"}""", 123)]
    [Arguments("""{"Value":"not a number"}""", null)]
    [Arguments("""{"Value":null}""", null)]
    [Arguments("""{"Value":""}""", null)]
    [Arguments("""{"Value":" "}""", null)]
    [Arguments("""{"Value":"     "}""", null)]
    public async Task Read_Numbers(string json, int? expected)
    {
        // Act
        var result = JsonSerializer.Deserialize<SampleClass2>(json);

        // Assert
        await Assert.That(result).IsNotNull();
        await Assert.That(result!.Value).IsEqualTo(expected);
    }
}

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Converters;

namespace Streamlabs.SocketClient.Tests.Converters;

[SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods")]
public class FlexibleObjectConverterTests
{
    private sealed class SampleClass
    {
        [JsonConverter(typeof(FlexibleObjectConverter<SamplePayload>))]
        public SamplePayload? Payload { get; set; }
    }

    private sealed class SamplePayload
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
        await Assert.That(result!.Payload).IsNotNull();
        await Assert.That(result.Payload!.Name).IsEqualTo("Alpha");
        await Assert.That(result.Payload.Count).IsEqualTo(3);
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
        await Assert.That(result!.Payload).IsNotNull();
        await Assert.That(result.Payload!.Name).IsEqualTo("Beta");
        await Assert.That(result.Payload.Count).IsEqualTo(7);
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
}

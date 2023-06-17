using Streamlabs.SocketClient.MessageTypes;

namespace Streamlabs.SocketClient.Tests;

public class MessageTypeTests
{
    [Theory]
    [InlineData("donation.json", typeof(DonationEvent))]
    public void MessageTypes_CanBeDeserialized(string fileName, Type expectedType)
    {
        // Arrange
        string json = File.ReadAllText(Path.Combine("./MessageJson", fileName));

        // Act
        var messages = json.Deserialize();

        // Assert
        messages.Should().HaveCount(1);
        messages.Should().AllBeOfType(expectedType);
    }
}

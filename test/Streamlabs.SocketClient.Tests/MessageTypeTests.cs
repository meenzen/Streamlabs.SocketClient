using Streamlabs.SocketClient.MessageTypes;
using System.Text;

namespace Streamlabs.SocketClient.Tests;

public class MessageTypeTests
{
    [Theory]
    [InlineData("donation.json", typeof(DonationEvent))]
    [InlineData("donationDelete.json", typeof(DonationDeleteEvent))]
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

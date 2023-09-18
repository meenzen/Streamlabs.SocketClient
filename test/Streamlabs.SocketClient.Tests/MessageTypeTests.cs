using Streamlabs.SocketClient.Events;
using Streamlabs.SocketClient.InternalExtensions;
using System.Text;

namespace Streamlabs.SocketClient.Tests;

public class MessageTypeTests
{
    [Theory]
    [InlineData("donation.json", typeof(DonationEvent))]
    [InlineData("bits.json", typeof(BitsEvent))]
    [InlineData("donationDelete.json", typeof(DonationDeleteEvent))]
    [InlineData("alertPlaying_subscription.json", typeof(AlertPlayingEvent))]
    [InlineData("alertPlaying_bits.json", typeof(AlertPlayingEvent))]
    [InlineData("follow.json", typeof(FollowEvent))]
    public void MessageTypes_CanBeDeserialized(string fileName, Type expectedType)
    {
        // Arrange
        string json = File.ReadAllText(Path.Combine("./MessageJson", fileName), Encoding.UTF8);

        // Act
        var messages = json.Deserialize();

        // Assert
        messages.Should().HaveCount(1);
        messages.Should().AllBeOfType(expectedType);
    }
}

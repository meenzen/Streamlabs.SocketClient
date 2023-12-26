using System.Text;
using FluentAssertions.Events;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using Streamlabs.SocketClient.Events;
using Streamlabs.SocketClient.InternalExtensions;

namespace Streamlabs.SocketClient.Tests;

public class MessageTypeTests
{
    public sealed record JsonFile(string FileName, Type ExpectedType, string? EventName = null)
    {
        public string GetJson() => File.ReadAllText(Path.Combine("./MessageJson", FileName), Encoding.UTF8);
    };

    public static IReadOnlyCollection<JsonFile> All { get; } =
        new List<JsonFile>
        {
            new("donation.json", typeof(DonationEvent)),
            new("bits.json", typeof(BitsEvent)),
            new("donationDelete.json", typeof(DonationDeleteEvent)),
            new("alertPlaying_subscription.json", typeof(AlertPlayingEvent), "SubscriptionAlertPlaying"),
            new("alertPlaying_bits.json", typeof(AlertPlayingEvent), "BitsAlertPlaying"),
            new("follow.json", typeof(FollowEvent)),
            new("raid.json", typeof(RaidEvent)),
            new("rollEndCredits.json", typeof(RollEndCreditsEvent)),
            new("streamlabels.json", typeof(StreamlabelsEvent)),
            new("streamlabelsUnderlying.json", typeof(StreamlabelsUnderlyingEvent)),
        };

    public static TheoryData<JsonFile> GetTheoryData()
    {
        var data = new TheoryData<JsonFile>();
        foreach (var jsonFile in All)
        {
            data.Add(jsonFile);
        }

        return data;
    }

    [Theory]
    [MemberData(nameof(GetTheoryData))]
    public void MessageTypes_CanBeDeserialized(JsonFile file)
    {
        // Arrange
        string json = file.GetJson();

        // Act
        var messages = json.Deserialize();

        // Assert
        messages.Should().HaveCount(1);
        messages.Should().AllBeOfType(file.ExpectedType);
    }

    [Theory]
    [MemberData(nameof(GetTheoryData))]
    public void Events_AreRaised_WhenMessageIsDispatched(JsonFile file)
    {
        // Arrange
        var logger = Substitute.For<ILogger<StreamlabsClient>>();
        var options = new StreamlabsOptions();
        var client = new StreamlabsClient(logger, new OptionsWrapper<StreamlabsOptions>(options));
        using IMonitor<StreamlabsClient> sut = client.Monitor();
        string json = file.GetJson();

        // Act
        client.Dispatch(json);

        // Assert
        sut.Should().Raise(nameof(client.OnEventRaw));
        sut.Should().Raise(nameof(client.OnEvent));
        string eventName = file.EventName ?? file.ExpectedType.Name.Replace("Event", string.Empty);
        sut.Should().Raise($"On{eventName}");
    }
}

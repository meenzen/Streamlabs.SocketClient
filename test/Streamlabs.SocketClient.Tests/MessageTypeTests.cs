using System.Text;
using FluentAssertions.Events;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using Streamlabs.SocketClient.Events;
using Streamlabs.SocketClient.InternalExtensions;
using Xunit.Abstractions;

namespace Streamlabs.SocketClient.Tests;

public class MessageTypeTests
{
    private const string CaptureDirectory = "../../../../../src/Streamlabs.EventCapture/events";
    private const string TestJsonDirectory = "./MessageJson";

    private readonly ITestOutputHelper _output;
    private readonly ILogger<StreamlabsClient> _logger = new ThrowingLogger<StreamlabsClient>(LogLevel.Error);

    public MessageTypeTests(ITestOutputHelper output)
    {
        _output = output;
    }

    public sealed record JsonFile(string FileName, Type ExpectedType, string? EventName = null)
    {
        public string GetJson() => File.ReadAllText(Path.Combine(TestJsonDirectory, FileName), Encoding.UTF8);
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
            new("subMysteryGift.json", typeof(SubMysteryGiftEvent)),
            new("subscription.json", typeof(SubscriptionEvent)),
            new("subscription2.json", typeof(SubscriptionEvent)),
            new("subscription3.json", typeof(SubscriptionEvent)),
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
        var options = new StreamlabsOptions();
        var client = new StreamlabsClient(_logger, new OptionsWrapper<StreamlabsOptions>(options));
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

    /// <summary>
    /// This test replays all events captured by the Streamlabs.EventCapture tool.
    /// </summary>
    [Fact]
    public void ReplayingCapturedEvents_IsSuccessful()
    {
        DirectoryInfo directoryInfo = new(CaptureDirectory);

        if (!directoryInfo.Exists)
        {
            _output.WriteLine("Capture directory does not exist. Run Streamlabs.EventCapture to capture events.");
            return;
        }

        FileInfo[] files = directoryInfo.GetFiles("*.json", SearchOption.AllDirectories);

        if (files.Length == 0)
        {
            _output.WriteLine("No events found. Run Streamlabs.EventCapture to capture events.");
            return;
        }

        foreach (FileInfo file in files)
        {
            string fileName = file.FullName.Replace(directoryInfo.FullName, string.Empty).TrimStart('/');
            _output.WriteLine($"Replaying: {fileName}");

            // Arrange
            var options = new StreamlabsOptions();
            var client = new StreamlabsClient(_logger, new OptionsWrapper<StreamlabsOptions>(options));
            using IMonitor<StreamlabsClient> sut = client.Monitor();
            string json = File.ReadAllText(file.FullName, Encoding.UTF8);

            // Act
            client.Dispatch(json);

            // Assert
            sut.Should().Raise(nameof(client.OnEventRaw));
            sut.Should().Raise(nameof(client.OnEvent));
        }
    }
}

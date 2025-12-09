using System.Diagnostics.CodeAnalysis;
using System.Text;
using AwesomeAssertions;
using AwesomeAssertions.Events;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Streamlabs.SocketClient.Events;
using Streamlabs.SocketClient.InternalExtensions;

namespace Streamlabs.SocketClient.Tests;

[SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods")]
public class MessageTypeTests
{
    private const string CaptureDirectory = "../../../../../src/Streamlabs.EventCapture/events";
    private const string TestJsonDirectory = "./MessageJson";

    private readonly ILogger<StreamlabsClient> _logger = new ThrowingLogger<StreamlabsClient>(LogLevel.Error);

    public sealed record JsonFile(string FileName, Type ExpectedType, string? EventName = null)
    {
        public string GetJson() => File.ReadAllText(Path.Combine(TestJsonDirectory, FileName), Encoding.UTF8);
    };

    public static IEnumerable<Func<JsonFile>> GetData()
    {
        yield return () => new JsonFile("alertPlaying.json", typeof(AlertPlayingEvent), "FollowAlertPlaying");
        yield return () =>
            new JsonFile("alertPlaying_subscription.json", typeof(AlertPlayingEvent), "SubscriptionAlertPlaying");
        yield return () => new JsonFile("alertPlaying_bits.json", typeof(AlertPlayingEvent), "BitsAlertPlaying");
        yield return () =>
            new JsonFile("alertPlaying_subMysteryGift.json", typeof(AlertPlayingEvent), "SubMysteryGiftAlertPlaying");
        yield return () => new JsonFile("alertPlaying_raid.json", typeof(AlertPlayingEvent), "RaidAlertPlaying");
        yield return () => new JsonFile("alertPlaying_follow.json", typeof(AlertPlayingEvent), "FollowAlertPlaying");
        yield return () => new JsonFile("bits.json", typeof(BitsEvent));
        yield return () => new JsonFile("bits2.json", typeof(BitsEvent));
        yield return () => new JsonFile("donation.json", typeof(DonationEvent));
        yield return () => new JsonFile("donationDelete.json", typeof(DonationDeleteEvent));
        yield return () => new JsonFile("follow.json", typeof(FollowEvent));
        yield return () => new JsonFile("muteVolume.json", typeof(MuteVolumeEvent));
        yield return () => new JsonFile("raid.json", typeof(RaidEvent));
        yield return () => new JsonFile("rollEndCredits.json", typeof(RollEndCreditsEvent));
        yield return () => new JsonFile("streamlabels.json", typeof(StreamlabelsEvent));
        yield return () => new JsonFile("streamlabelsUnderlying.json", typeof(StreamlabelsUnderlyingEvent));
        yield return () => new JsonFile("streamlabelsUnderlying2.json", typeof(StreamlabelsUnderlyingEvent));
        yield return () => new JsonFile("subMysteryGift.json", typeof(SubMysteryGiftEvent));
        yield return () => new JsonFile("subMysteryGift1.json", typeof(SubMysteryGiftEvent));
        yield return () => new JsonFile("subscription.json", typeof(SubscriptionEvent));
        yield return () => new JsonFile("subscription2.json", typeof(SubscriptionEvent));
        yield return () => new JsonFile("subscription3.json", typeof(SubscriptionEvent));
        yield return () =>
            new JsonFile("subscriptionPlaying.json", typeof(SubscriptionPlayingEvent), "SubscriptionPlaying");
    }

    [Test]
    [MethodDataSource(nameof(GetData))]
    public async Task MessageTypes_CanBeDeserialized(JsonFile file)
    {
        // Arrange
        string json = file.GetJson();

        // Act
        var messages = json.Deserialize();

        // Assert
        await Assert.That(messages).Count().IsEqualTo(1);
        await Assert.That(messages).All().Satisfy(x => x.IsOfType(file.ExpectedType));
    }

    [Test]
    [MethodDataSource(nameof(GetData))]
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

    public static IEnumerable<Func<string>> GetCapturedEvents()
    {
        DirectoryInfo directoryInfo = new(CaptureDirectory);

        if (!directoryInfo.Exists)
        {
            TestContext.Current?.OutputWriter.WriteLine(
                "Capture directory does not exist. Run Streamlabs.EventCapture to capture events."
            );
            yield break;
        }

        FileInfo[] files = directoryInfo.GetFiles("*.json", SearchOption.AllDirectories);

        if (files.Length == 0)
        {
            TestContext.Current?.OutputWriter.WriteLine(
                "No events found. Run Streamlabs.EventCapture to capture events."
            );
            yield break;
        }

        foreach (FileInfo file in files)
        {
            yield return () => file.FullName;
        }
    }

    /// <summary>
    /// This test replays all events captured by the Streamlabs.EventCapture tool.
    /// </summary>
    [Test]
    [MethodDataSource(nameof(GetCapturedEvents))]
    public void ReplayingCapturedEvents_IsSuccessful(string filePath)
    {
        // Arrange
        var options = new StreamlabsOptions();
        var client = new StreamlabsClient(_logger, new OptionsWrapper<StreamlabsOptions>(options));
        using IMonitor<StreamlabsClient> sut = client.Monitor();
        string json = File.ReadAllText(filePath, Encoding.UTF8);

        // Act
        client.Dispatch(json);

        // Assert
        sut.Should().Raise(nameof(client.OnEventRaw));
        sut.Should().Raise(nameof(client.OnEvent));
    }
}

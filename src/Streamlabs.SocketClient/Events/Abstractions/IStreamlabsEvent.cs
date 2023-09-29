using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Events.Abstractions;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(DonationEvent), typeDiscriminator: "donation")]
[JsonDerivedType(typeof(DonationDeleteEvent), typeDiscriminator: "donationDelete")]
[JsonDerivedType(typeof(AlertPlayingEvent), typeDiscriminator: "alertPlaying")]
[JsonDerivedType(typeof(BitsEvent), typeDiscriminator: "bits")]
[JsonDerivedType(typeof(FollowEvent), typeDiscriminator: "follow")]
[JsonDerivedType(typeof(RaidEvent), typeDiscriminator: "raid")]
[JsonDerivedType(typeof(RollEndCreditsEvent), typeDiscriminator: "rollEndCredits")]
public interface IStreamlabsEvent { }

using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Events.Abstractions;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(DonationEvent), typeDiscriminator: "donation")]
[JsonDerivedType(typeof(DonationDeleteEvent), typeDiscriminator: "donationDelete")]
[JsonDerivedType(typeof(AlertPlayingEvent), typeDiscriminator: "alertPlaying")]
[JsonDerivedType(typeof(BitsEvent), typeDiscriminator: "bits")]
public interface IStreamlabsEvent { }

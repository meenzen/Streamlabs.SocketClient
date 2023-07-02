using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Events.Abstractions;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(DonationEvent), typeDiscriminator: "donation")]
[JsonDerivedType(typeof(DonationDeleteEvent), typeDiscriminator: "donationDelete")]
[JsonDerivedType(typeof(AlertPlayingEvent), typeDiscriminator: "alertPlaying")]
public interface IStreamlabsEvent { }

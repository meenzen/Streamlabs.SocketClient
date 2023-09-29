using Streamlabs.SocketClient.Messages.Abstractions;
using System.Text.Json.Serialization;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public sealed record RollEndCreditsSettings : IHasMessageId, IHasPriority
{
    [JsonPropertyName("theme")]
    public required string Theme { get; init; }

    [JsonPropertyName("donations")]
    public required bool Donations { get; init; }

    [JsonPropertyName("credit_title")]
    public required string CreditTitle { get; init; }

    [JsonPropertyName("credit_subtitle")]
    public required string CreditSubTitle { get; init; }

    [JsonPropertyName("donor_change")]
    public required string DonorChange { get; init; }

    [JsonPropertyName("loop_credits")]
    public required bool LoopCredits { get; init; }

    [JsonPropertyName("delay_time")]
    public required int DelayTime { get; init; }

    [JsonPropertyName("roll_speed")]
    public required int RollSpeed { get; init; }

    /// <summary>
    /// The background color (hex)
    /// </summary>
    [JsonPropertyName("background_color")]
    public required string BackgroundColor { get; init; }

    [JsonPropertyName("font")]
    public required string Font { get; init; }

    /// <summary>
    /// The font color (hex)
    /// </summary>
    [JsonPropertyName("font_color")]
    public required string FontColor { get; init; }

    [JsonPropertyName("font_size")]
    public required int FontSize { get; init; }

    [JsonPropertyName("roll_time")]
    public required int RollTime { get; init; }

    [JsonPropertyName("roll_options")]
    public required string RollOptions { get; init; }

    [JsonPropertyName("custom_enabled")]
    public required bool CustomEnabled { get; init; }

    [JsonPropertyName("custom_html")]
    public required string CustomHtml { get; init; }

    [JsonPropertyName("custom_css")]
    public required string CustomCss { get; init; }

    [JsonPropertyName("custom_js")]
    public required string CustomJs { get; init; }

    [JsonPropertyName("custom_json")]
    public required string? CustomJson { get; init; }

    [JsonPropertyName("show_amounts")]
    public required bool ShowAmounts { get; init; }

    [JsonPropertyName("roll_credits_on_load")]
    public required bool RollCreditsOnLoad { get; init; }

    [JsonPropertyName("followers")]
    public required bool Followers { get; init; }

    [JsonPropertyName("subscribers")]
    public required bool Subscribers { get; init; }

    [JsonPropertyName("bits")]
    public required bool Bits { get; init; }

    [JsonPropertyName("moderators")]
    public required bool Moderators { get; init; }

    [JsonPropertyName("raids")]
    public required bool Raids { get; init; }

    [JsonPropertyName("hosts")]
    public required bool Hosts { get; init; }

    [JsonPropertyName("followers_change")]
    public required string FollowersChange { get; init; }

    /// <summary>
    /// This property is HTML encoded
    /// </summary>
    [JsonPropertyName("subscribers_change")]
    public required string SubscribersChange { get; init; }

    [JsonPropertyName("bits_change")]
    public required string BitsChange { get; init; }

    [JsonPropertyName("mods_change")]
    public required string ModsChange { get; init; }

    [JsonPropertyName("raids_change")]
    public required string RaidsChange { get; init; }

    [JsonPropertyName("hosts_change")]
    public required string HostsChange { get; init; }

    [JsonPropertyName("_id")]
    public required string MessageId { get; init; }

    [JsonPropertyName("priority")]
    public required long Priority { get; init; }
}

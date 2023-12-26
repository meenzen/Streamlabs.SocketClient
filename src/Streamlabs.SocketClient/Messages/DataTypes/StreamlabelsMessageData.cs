using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Converters;
using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public sealed record StreamlabelsMessageData : IHasMessageId, IHasPriority
{
    [JsonPropertyName("donation_goal")]
    public required string DonationGoal { get; init; }

    [JsonPropertyName("most_recent_donator")]
    public required string MostRecentDonator { get; init; }

    [JsonPropertyName("session_most_recent_donator")]
    public required string SessionMostRecentDonator { get; init; }

    [JsonPropertyName("session_donators")]
    public required string SessionDonators { get; init; }

    [JsonPropertyName("total_donation_amount")]
    public required string TotalDonationAmount { get; init; }

    [JsonPropertyName("monthly_donation_amount")]
    public required string MonthlyDonationAmount { get; init; }

    [JsonPropertyName("weekly_donation_amount")]
    public required string WeeklyDonationAmount { get; init; }

    [JsonPropertyName("30day_donation_amount")]
    public required string ThirtyDayDonationAmount { get; init; }

    [JsonPropertyName("session_donation_amount")]
    public required string SessionDonationAmount { get; init; }

    [JsonPropertyName("all_time_top_donator")]
    public required string AllTimeTopDonator { get; init; }

    [JsonPropertyName("monthly_top_donator")]
    public required string MonthlyTopDonator { get; init; }

    [JsonPropertyName("weekly_top_donator")]
    public required string WeeklyTopDonator { get; init; }

    [JsonPropertyName("30day_top_donator")]
    public required string ThirtyDayTopDonator { get; init; }

    [JsonPropertyName("session_top_donator")]
    public required string SessionTopDonator { get; init; }

    [JsonPropertyName("all_time_top_donators")]
    public required string AllTimeTopDonators { get; init; }

    [JsonPropertyName("monthly_top_donators")]
    public required string MonthlyTopDonators { get; init; }

    [JsonPropertyName("weekly_top_donators")]
    public required string WeeklyTopDonators { get; init; }

    [JsonPropertyName("30day_top_donators")]
    public required string ThirtyDayTopDonators { get; init; }

    [JsonPropertyName("session_top_donators")]
    public required string SessionTopDonators { get; init; }

    [JsonPropertyName("all_time_top_donations")]
    public required string AllTimeTopDonations { get; init; }

    [JsonPropertyName("monthly_top_donations")]
    public required string MonthlyTopDonations { get; init; }

    [JsonPropertyName("weekly_top_donations")]
    public required string WeeklyTopDonations { get; init; }

    [JsonPropertyName("30day_top_donations")]
    public required string ThirtyDayTopDonations { get; init; }

    [JsonPropertyName("session_top_donations")]
    public required string SessionTopDonations { get; init; }

    [JsonPropertyName("all_time_top_monthly_donator")]
    public required string AllTimeTopMonthlyDonator { get; init; }

    [JsonPropertyName("monthly_top_monthly_donator")]
    public required string MonthlyTopMonthlyDonator { get; init; }

    [JsonPropertyName("weekly_top_monthly_donator")]
    public required string WeeklyTopMonthlyDonator { get; init; }

    [JsonPropertyName("30day_top_monthly_donator")]
    public required string ThirtyDayTopMonthlyDonator { get; init; }

    [JsonPropertyName("session_top_monthly_donator")]
    public required string SessionTopMonthlyDonator { get; init; }

    [JsonPropertyName("all_time_top_monthly_donators")]
    public required string AllTimeTopMonthlyDonators { get; init; }

    [JsonPropertyName("monthly_top_monthly_donators")]
    public required string MonthlyTopMonthlyDonators { get; init; }

    [JsonPropertyName("weekly_top_monthly_donators")]
    public required string WeeklyTopMonthlyDonators { get; init; }

    [JsonPropertyName("30day_top_monthly_donators")]
    public required string ThirtyDayTopMonthlyDonators { get; init; }

    [JsonPropertyName("session_top_monthly_donators")]
    public required string SessionTopMonthlyDonators { get; init; }

    [JsonPropertyName("total_monthly_donator_count")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int TotalMonthlyDonatorCount { get; init; }

    [JsonPropertyName("monthly_monthly_donator_count")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int MonthlyMonthlyDonatorCount { get; init; }

    [JsonPropertyName("weekly_monthly_donator_count")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int WeeklyMonthlyDonatorCount { get; init; }

    [JsonPropertyName("30day_monthly_donator_count")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int ThirtyDayMonthlyDonatorCount { get; init; }

    [JsonPropertyName("session_monthly_donator_count")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int SessionMonthlyDonatorCount { get; init; }

    [JsonPropertyName("most_recent_monthly_donator")]
    public required string MostRecentMonthlyDonator { get; init; }

    [JsonPropertyName("session_monthly_donators")]
    public required string SessionMonthlyDonators { get; init; }

    [JsonPropertyName("session_most_recent_monthly_donator")]
    public required string SessionMostRecentMonthlyDonator { get; init; }

    [JsonPropertyName("cloudbot_counter_deaths")]
    public required string CloudbotCounterDeaths { get; init; }

    [JsonPropertyName("monthly_subscriber_count")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int MonthlySubscriberCount { get; init; }

    [JsonPropertyName("weekly_subscriber_count")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int WeeklySubscriberCount { get; init; }

    [JsonPropertyName("30day_subscriber_count")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int ThirtyDaySubscriberCount { get; init; }

    [JsonPropertyName("session_subscriber_count")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int SessionSubscriberCount { get; init; }

    [JsonPropertyName("session_follower_count")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int SessionFollowerCount { get; init; }

    [JsonPropertyName("session_most_recent_follower")]
    public required string SessionMostRecentFollower { get; init; }

    [JsonPropertyName("session_most_recent_subscriber")]
    public required string SessionMostRecentSubscriber { get; init; }

    [JsonPropertyName("session_most_recent_resubscriber")]
    public required string SessionMostRecentResubscriber { get; init; }

    [JsonPropertyName("session_subscribers")]
    public required string SessionSubscribers { get; init; }

    [JsonPropertyName("session_followers")]
    public required string SessionFollowers { get; init; }

    [JsonPropertyName("most_recent_follower")]
    public required string MostRecentFollower { get; init; }

    [JsonPropertyName("most_recent_subscriber")]
    public required string MostRecentSubscriber { get; init; }

    [JsonPropertyName("most_recent_resubscriber")]
    public required string MostRecentResubscriber { get; init; }

    [JsonPropertyName("total_follower_count")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int TotalFollowerCount { get; init; }

    [JsonPropertyName("total_subscriber_count")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int TotalSubscriberCount { get; init; }

    [JsonPropertyName("total_subscriber_score")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int TotalSubscriberScore { get; init; }

    [JsonPropertyName("monthly_subscriber_score")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int MonthlySubscriberScore { get; init; }

    [JsonPropertyName("weekly_subscriber_score")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int WeeklySubscriberScore { get; init; }

    [JsonPropertyName("30day_subscriber_score")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int ThirtyDaySubscriberScore { get; init; }

    [JsonPropertyName("session_subscriber_score")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int SessionSubscriberScore { get; init; }

    [JsonPropertyName("most_recent_cheerer")]
    public required string MostRecentCheerer { get; init; }

    [JsonPropertyName("session_most_recent_cheerer")]
    public required string SessionMostRecentCheerer { get; init; }

    [JsonPropertyName("session_cheerers")]
    public required string SessionCheerers { get; init; }

    [JsonPropertyName("total_cheer_amount")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int TotalCheerAmount { get; init; }

    [JsonPropertyName("monthly_cheer_amount")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int MonthlyCheerAmount { get; init; }

    [JsonPropertyName("weekly_cheer_amount")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int WeeklyCheerAmount { get; init; }

    [JsonPropertyName("30day_cheer_amount")]
    [JsonConverter(typeof(IntStringConverter))]
    public required int ThirtyDayCheerAmount { get; init; }

    [JsonPropertyName("session_cheer_amount")]
    public required int SessionCheerAmount { get; init; }

    [JsonPropertyName("all_time_top_cheerer")]
    public required string AllTimeTopCheerer { get; init; }

    [JsonPropertyName("monthly_top_cheerer")]
    public required string MonthlyTopCheerer { get; init; }

    [JsonPropertyName("weekly_top_cheerer")]
    public required string WeeklyTopCheerer { get; init; }

    [JsonPropertyName("30day_top_cheerer")]
    public required string ThirtyDayTopCheerer { get; init; }

    [JsonPropertyName("session_top_cheerer")]
    public required string SessionTopCheerer { get; init; }

    [JsonPropertyName("all_time_top_cheerers")]
    public required string AllTimeTopCheerers { get; init; }

    [JsonPropertyName("monthly_top_cheerers")]
    public required string MonthlyTopCheerers { get; init; }

    [JsonPropertyName("weekly_top_cheerers")]
    public required string WeeklyTopCheerers { get; init; }

    [JsonPropertyName("30day_top_cheerers")]
    public required string ThirtyDayTopCheerers { get; init; }

    [JsonPropertyName("session_top_cheerers")]
    public required string SessionTopCheerers { get; init; }

    [JsonPropertyName("all_time_top_cheers")]
    public required string AllTimeTopCheers { get; init; }

    [JsonPropertyName("monthly_top_cheers")]
    public required string MonthlyTopCheers { get; init; }

    [JsonPropertyName("30day_top_cheers")]
    public required string ThirtyDayTopCheers { get; init; }

    [JsonPropertyName("weekly_top_cheers")]
    public required string WeeklyTopCheers { get; init; }

    [JsonPropertyName("session_top_cheers")]
    public required string SessionTopCheers { get; init; }

    [JsonPropertyName("all_time_top_sub_gifters")]
    public required string AllTimeTopSubGifters { get; init; }

    [JsonPropertyName("monthly_top_sub_gifters")]
    public required string MonthlyTopSubGifters { get; init; }

    [JsonPropertyName("weekly_top_sub_gifters")]
    public required string WeeklyTopSubGifters { get; init; }

    [JsonPropertyName("30day_top_sub_gifters")]
    public required string ThirtyDayTopSubGifters { get; init; }

    [JsonPropertyName("session_top_sub_gifters")]
    public required string SessionTopSubGifters { get; init; }

    [JsonPropertyName("most_recent_sub_gifter")]
    public required string MostRecentSubGifter { get; init; }

    [JsonPropertyName("session_sub_gifters")]
    public required string SessionSubGifters { get; init; }

    [JsonPropertyName("session_most_recent_sub_gifter")]
    public required string SessionMostRecentSubGifter { get; init; }

    [JsonPropertyName("all_time_top_sub_gifter")]
    public required string AllTimeTopSubGifter { get; init; }

    [JsonPropertyName("monthly_top_sub_gifter")]
    public required string MonthlyTopSubGifter { get; init; }

    [JsonPropertyName("weekly_top_sub_gifter")]
    public required string WeeklyTopSubGifter { get; init; }

    [JsonPropertyName("30day_top_sub_gifter")]
    public required string ThirtyDayTopSubGifter { get; init; }

    [JsonPropertyName("session_top_sub_gifter")]
    public required string SessionTopSubGifter { get; init; }

    [JsonPropertyName("monthly_top_subscriber")]
    public required string MonthlyTopSubscriber { get; init; }

    [JsonPropertyName("weekly_top_subscriber")]
    public required string WeeklyTopSubscriber { get; init; }

    [JsonPropertyName("30day_top_subscriber")]
    public required string ThirtyDayTopSubscriber { get; init; }

    [JsonPropertyName("session_top_subscriber")]
    public required string SessionTopSubscriber { get; init; }

    [JsonPropertyName("monthly_top_subscribers")]
    public required string MonthlyTopSubscribers { get; init; }

    [JsonPropertyName("weekly_top_subscribers")]
    public required string WeeklyTopSubscribers { get; init; }

    [JsonPropertyName("30day_top_subscribers")]
    public required string ThirtyDayTopSubscribers { get; init; }

    [JsonPropertyName("session_top_subscribers")]
    public required string SessionTopSubscribers { get; init; }

    [JsonPropertyName("_id")]
    public required string MessageId { get; init; }

    [JsonPropertyName("priority")]
    public long Priority { get; init; }
}

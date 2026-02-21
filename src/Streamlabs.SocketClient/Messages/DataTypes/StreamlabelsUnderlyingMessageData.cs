using System.Text.Json.Serialization;
using Streamlabs.SocketClient.Converters;
using Streamlabs.SocketClient.Messages.Abstractions;

namespace Streamlabs.SocketClient.Messages.DataTypes;

public sealed record StreamlabelsUnderlyingMessageData : IHasMessageId, IHasPriority
{
    [JsonPropertyName("donation_goal")]
    [JsonConverter(typeof(FlexibleObjectConverter<StreamlabelsUnderlyingMessageDonationGoal>))]
    public StreamlabelsUnderlyingMessageDonationGoal? DonationGoal { get; init; }

    [JsonPropertyName("most_recent_donator")]
    public required Donator MostRecentDonator { get; init; }

    [JsonPropertyName("session_most_recent_donator")]
    [JsonConverter(typeof(FlexibleObjectConverter<Donator>))]
    public Donator? SessionMostRecentDonator { get; init; }

    [JsonPropertyName("session_donators")]
    [JsonConverter(typeof(FlexibleObjectConverter<IReadOnlyCollection<Donator>>))]
    public IReadOnlyCollection<Donator>? SessionDonators { get; init; }

    [JsonPropertyName("total_donation_amount")]
    public required DonationAmount TotalDonationAmount { get; init; }

    [JsonPropertyName("monthly_donation_amount")]
    public required DonationAmount MonthlyDonationAmount { get; init; }

    [JsonPropertyName("weekly_donation_amount")]
    public required DonationAmount WeeklyDonationAmount { get; init; }

    [JsonPropertyName("30day_donation_amount")]
    public required DonationAmount ThirtyDayDonationAmount { get; init; }

    [JsonPropertyName("session_donation_amount")]
    public required DonationAmount SessionDonationAmount { get; init; }

    [JsonPropertyName("all_time_top_donator")]
    public required TopDonator AllTimeTopDonator { get; init; }

    [JsonPropertyName("monthly_top_donator")]
    [JsonConverter(typeof(FlexibleObjectConverter<TopDonator>))]
    public TopDonator? MonthlyTopDonator { get; init; }

    [JsonPropertyName("weekly_top_donator")]
    [JsonConverter(typeof(FlexibleObjectConverter<TopDonator>))]
    public TopDonator? WeeklyTopDonator { get; init; }

    [JsonPropertyName("30day_top_donator")]
    [JsonConverter(typeof(FlexibleObjectConverter<TopDonator>))]
    public TopDonator? ThirtyDayTopDonator { get; init; }

    [JsonPropertyName("session_top_donator")]
    [JsonConverter(typeof(FlexibleObjectConverter<TopDonator>))]
    public TopDonator? SessionTopDonator { get; init; }

    [JsonPropertyName("all_time_top_donators")]
    [JsonConverter(typeof(FlexibleObjectConverter<IReadOnlyCollection<TopDonator>>))]
    public IReadOnlyCollection<TopDonator>? AllTimeTopDonators { get; init; }

    [JsonPropertyName("monthly_top_donators")]
    [JsonConverter(typeof(FlexibleObjectConverter<IReadOnlyCollection<TopDonator>>))]
    public IReadOnlyCollection<TopDonator>? MonthlyTopDonators { get; init; }

    [JsonPropertyName("weekly_top_donators")]
    [JsonConverter(typeof(FlexibleObjectConverter<IReadOnlyCollection<TopDonator>>))]
    public IReadOnlyCollection<TopDonator>? WeeklyTopDonators { get; init; }

    [JsonPropertyName("30day_top_donators")]
    [JsonConverter(typeof(FlexibleObjectConverter<IReadOnlyCollection<TopDonator>>))]
    public IReadOnlyCollection<TopDonator>? ThirtyDayTopDonators { get; init; }

    [JsonPropertyName("session_top_donators")]
    [JsonConverter(typeof(FlexibleObjectConverter<IReadOnlyCollection<TopDonator>>))]
    public IReadOnlyCollection<TopDonator>? SessionTopDonators { get; init; }

    [JsonPropertyName("all_time_top_donations")]
    public required IReadOnlyCollection<TopDonationAmount> AllTimeTopDonations { get; init; }

    [JsonPropertyName("monthly_top_donations")]
    public required IReadOnlyCollection<TopDonationAmount> MonthlyTopDonations { get; init; }

    [JsonPropertyName("weekly_top_donations")]
    public required IReadOnlyCollection<TopDonationAmount> WeeklyTopDonations { get; init; }

    [JsonPropertyName("30day_top_donations")]
    public required IReadOnlyCollection<TopDonationAmount> ThirtyDayTopDonations { get; init; }

    [JsonPropertyName("session_top_donations")]
    public required IReadOnlyCollection<TopDonationAmount> SessionTopDonations { get; init; }

    [JsonPropertyName("all_time_top_monthly_donator")]
    public required TopDonator AllTimeTopMonthlyDonator { get; init; }

    [JsonPropertyName("monthly_top_monthly_donator")]
    public required string MonthlyTopMonthlyDonator { get; init; }

    [JsonPropertyName("weekly_top_monthly_donator")]
    public required string WeeklyTopMonthlyDonator { get; init; }

    [JsonPropertyName("30day_top_monthly_donator")]
    public required string ThirtyDayTopMonthlyDonator { get; init; }

    [JsonPropertyName("session_top_monthly_donator")]
    public required string SessionTopMonthlyDonator { get; init; }

    [JsonPropertyName("all_time_top_monthly_donators")]
    public required IReadOnlyCollection<TopDonator> AllTimeTopMonthlyDonators { get; init; }

    [JsonPropertyName("monthly_top_monthly_donators")]
    public required string MonthlyTopMonthlyDonators { get; init; }

    [JsonPropertyName("weekly_top_monthly_donators")]
    public required string WeeklyTopMonthlyDonators { get; init; }

    [JsonPropertyName("30day_top_monthly_donators")]
    public required string ThirtyDayTopMonthlyDonators { get; init; }

    [JsonPropertyName("session_top_monthly_donators")]
    public required string SessionTopMonthlyDonators { get; init; }

    [JsonPropertyName("total_monthly_donator_count")]
    public required Count TotalMonthlyDonatorCount { get; init; }

    [JsonPropertyName("monthly_monthly_donator_count")]
    public required Count MonthlyMonthlyDonatorCount { get; init; }

    [JsonPropertyName("weekly_monthly_donator_count")]
    public required Count WeeklyMonthlyDonatorCount { get; init; }

    [JsonPropertyName("30day_monthly_donator_count")]
    public required Count ThirtyDayMonthlyDonatorCount { get; init; }

    [JsonPropertyName("session_monthly_donator_count")]
    public required Count SessionMonthlyDonatorCount { get; init; }

    [JsonPropertyName("most_recent_monthly_donator")]
    public required Donator MostRecentMonthlyDonator { get; init; }

    [JsonPropertyName("session_monthly_donators")]
    public required string SessionMonthlyDonators { get; init; }

    [JsonPropertyName("session_most_recent_monthly_donator")]
    public required string SessionMostRecentMonthlyDonator { get; init; }

    [JsonPropertyName("cloudbot_counter_deaths")]
    public Counter? CloudbotCounterDeaths { get; init; }

    [JsonPropertyName("monthly_subscriber_count")]
    public required Count MonthlySubscriberCount { get; init; }

    [JsonPropertyName("weekly_subscriber_count")]
    public required Count WeeklySubscriberCount { get; init; }

    [JsonPropertyName("30day_subscriber_count")]
    public required Count ThirtyDaySubscriberCount { get; init; }

    [JsonPropertyName("session_subscriber_count")]
    public required Count SessionSubscriberCount { get; init; }

    [JsonPropertyName("session_follower_count")]
    public required Count SessionFollowerCount { get; init; }

    [JsonPropertyName("session_most_recent_follower")]
    public required Name SessionMostRecentFollower { get; init; }

    [JsonPropertyName("session_most_recent_subscriber")]
    public required Subscriber SessionMostRecentSubscriber { get; init; }

    [JsonPropertyName("session_most_recent_resubscriber")]
    public required Subscriber SessionMostRecentResubscriber { get; init; }

    [JsonPropertyName("session_subscribers")]
    public required IReadOnlyCollection<Subscriber> SessionSubscribers { get; init; }

    [JsonPropertyName("session_followers")]
    public required IReadOnlyCollection<Name> SessionFollowers { get; init; }

    [JsonPropertyName("most_recent_follower")]
    public required Name MostRecentFollower { get; init; }

    [JsonPropertyName("most_recent_subscriber")]
    public required Subscriber MostRecentSubscriber { get; init; }

    [JsonPropertyName("most_recent_resubscriber")]
    public required Subscriber MostRecentResubscriber { get; init; }

    [JsonPropertyName("total_follower_count")]
    public required Count TotalFollowerCount { get; init; }

    [JsonPropertyName("total_subscriber_count")]
    public required Count TotalSubscriberCount { get; init; }

    [JsonPropertyName("total_subscriber_score")]
    public required Count TotalSubscriberScore { get; init; }

    [JsonPropertyName("monthly_subscriber_score")]
    public required Count MonthlySubscriberScore { get; init; }

    [JsonPropertyName("weekly_subscriber_score")]
    public required Count WeeklySubscriberScore { get; init; }

    [JsonPropertyName("30day_subscriber_score")]
    public required Count ThirtyDaySubscriberScore { get; init; }

    [JsonPropertyName("session_subscriber_score")]
    public required Count SessionSubscriberScore { get; init; }

    [JsonPropertyName("most_recent_cheerer")]
    [JsonConverter(typeof(EmptyStringToNullConverter<Cheerer>))]
    public required Cheerer? MostRecentCheerer { get; init; }

    [JsonPropertyName("session_most_recent_cheerer")]
    [JsonConverter(typeof(EmptyStringToNullConverter<Cheerer>))]
    public required Cheerer? SessionMostRecentCheerer { get; init; }

    [JsonPropertyName("session_cheerers")]
    [JsonConverter(typeof(EmptyStringToNullConverter<IReadOnlyCollection<Cheerer>>))]
    public required IReadOnlyCollection<Cheerer>? SessionCheerers { get; init; }

    [JsonPropertyName("total_cheer_amount")]
    public required Amount TotalCheerAmount { get; init; }

    [JsonPropertyName("monthly_cheer_amount")]
    public required Amount MonthlyCheerAmount { get; init; }

    [JsonPropertyName("weekly_cheer_amount")]
    public required Amount WeeklyCheerAmount { get; init; }

    [JsonPropertyName("30day_cheer_amount")]
    public required Amount ThirtyDayCheerAmount { get; init; }

    [JsonPropertyName("session_cheer_amount")]
    public required Amount SessionCheerAmount { get; init; }

    [JsonPropertyName("all_time_top_cheerer")]
    [JsonConverter(typeof(EmptyStringToNullConverter<TopCheerer>))]
    public required TopCheerer? AllTimeTopCheerer { get; init; }

    [JsonPropertyName("monthly_top_cheerer")]
    [JsonConverter(typeof(EmptyStringToNullConverter<TopCheerer>))]
    public required TopCheerer? MonthlyTopCheerer { get; init; }

    [JsonPropertyName("weekly_top_cheerer")]
    [JsonConverter(typeof(EmptyStringToNullConverter<TopCheerer>))]
    public required TopCheerer? WeeklyTopCheerer { get; init; }

    [JsonPropertyName("30day_top_cheerer")]
    [JsonConverter(typeof(EmptyStringToNullConverter<TopCheerer>))]
    public required TopCheerer? ThirtyDayTopCheerer { get; init; }

    [JsonPropertyName("session_top_cheerer")]
    [JsonConverter(typeof(EmptyStringToNullConverter<TopCheerer>))]
    public required TopCheerer? SessionTopCheerer { get; init; }

    [JsonPropertyName("all_time_top_cheerers")]
    [JsonConverter(typeof(EmptyStringToNullConverter<IReadOnlyCollection<TopCheerer>>))]
    public required IReadOnlyCollection<TopCheerer>? AllTimeTopCheerers { get; init; }

    [JsonPropertyName("monthly_top_cheerers")]
    [JsonConverter(typeof(EmptyStringToNullConverter<IReadOnlyCollection<TopCheerer>>))]
    public required IReadOnlyCollection<TopCheerer>? MonthlyTopCheerers { get; init; }

    [JsonPropertyName("weekly_top_cheerers")]
    [JsonConverter(typeof(EmptyStringToNullConverter<IReadOnlyCollection<TopCheerer>>))]
    public required IReadOnlyCollection<TopCheerer>? WeeklyTopCheerers { get; init; }

    [JsonPropertyName("30day_top_cheerers")]
    [JsonConverter(typeof(EmptyStringToNullConverter<IReadOnlyCollection<TopCheerer>>))]
    public required IReadOnlyCollection<TopCheerer>? ThirtyDayTopCheerers { get; init; }

    [JsonPropertyName("session_top_cheerers")]
    [JsonConverter(typeof(EmptyStringToNullConverter<IReadOnlyCollection<TopCheerer>>))]
    public required IReadOnlyCollection<TopCheerer>? SessionTopCheerers { get; init; }

    [JsonPropertyName("all_time_top_cheers")]
    [JsonConverter(typeof(EmptyStringToNullConverter<IReadOnlyCollection<Cheerer>>))]
    public required IReadOnlyCollection<Cheerer>? AllTimeTopCheers { get; init; }

    [JsonPropertyName("monthly_top_cheers")]
    [JsonConverter(typeof(EmptyStringToNullConverter<IReadOnlyCollection<Cheerer>>))]
    public required IReadOnlyCollection<Cheerer>? MonthlyTopCheers { get; init; }

    [JsonPropertyName("30day_top_cheers")]
    [JsonConverter(typeof(EmptyStringToNullConverter<IReadOnlyCollection<Cheerer>>))]
    public required IReadOnlyCollection<Cheerer>? ThirtyDayTopCheers { get; init; }

    [JsonPropertyName("weekly_top_cheers")]
    [JsonConverter(typeof(EmptyStringToNullConverter<IReadOnlyCollection<Cheerer>>))]
    public required IReadOnlyCollection<Cheerer>? WeeklyTopCheers { get; init; }

    [JsonPropertyName("session_top_cheers")]
    [JsonConverter(typeof(EmptyStringToNullConverter<IReadOnlyCollection<Cheerer>>))]
    public required IReadOnlyCollection<Cheerer>? SessionTopCheers { get; init; }

    [JsonPropertyName("all_time_top_sub_gifters")]
    public required IReadOnlyCollection<TopGifter> AllTimeTopSubGifters { get; init; }

    [JsonPropertyName("monthly_top_sub_gifters")]
    public required IReadOnlyCollection<TopGifter> MonthlyTopSubGifters { get; init; }

    [JsonPropertyName("weekly_top_sub_gifters")]
    public required IReadOnlyCollection<TopGifter> WeeklyTopSubGifters { get; init; }

    [JsonPropertyName("30day_top_sub_gifters")]
    public required IReadOnlyCollection<TopGifter> ThirtyDayTopSubGifters { get; init; }

    [JsonPropertyName("session_top_sub_gifters")]
    public required IReadOnlyCollection<TopGifter> SessionTopSubGifters { get; init; }

    [JsonPropertyName("most_recent_sub_gifter")]
    public required Name MostRecentSubGifter { get; init; }

    [JsonPropertyName("session_sub_gifters")]
    [JsonConverter(typeof(EmptyStringToNullConverter<IReadOnlyCollection<Name>>))]
    public required IReadOnlyCollection<Name>? SessionSubGifters { get; init; }

    [JsonPropertyName("session_most_recent_sub_gifter")]
    [JsonConverter(typeof(EmptyStringToNullConverter<Name>))]
    public required Name SessionMostRecentSubGifter { get; init; }

    [JsonPropertyName("all_time_top_sub_gifter")]
    [JsonConverter(typeof(EmptyStringToNullConverter<TopGifter>))]
    public required TopGifter? AllTimeTopSubGifter { get; init; }

    [JsonPropertyName("monthly_top_sub_gifter")]
    [JsonConverter(typeof(EmptyStringToNullConverter<TopGifter>))]
    public required TopGifter? MonthlyTopSubGifter { get; init; }

    [JsonPropertyName("weekly_top_sub_gifter")]
    [JsonConverter(typeof(EmptyStringToNullConverter<TopGifter>))]
    public required TopGifter? WeeklyTopSubGifter { get; init; }

    [JsonPropertyName("30day_top_sub_gifter")]
    [JsonConverter(typeof(EmptyStringToNullConverter<TopGifter>))]
    public required TopGifter? ThirtyDayTopSubGifter { get; init; }

    [JsonPropertyName("session_top_sub_gifter")]
    [JsonConverter(typeof(EmptyStringToNullConverter<TopGifter>))]
    public required TopGifter? SessionTopSubGifter { get; init; }

    [JsonPropertyName("monthly_top_subscriber")]
    public required Subscriber MonthlyTopSubscriber { get; init; }

    [JsonPropertyName("weekly_top_subscriber")]
    public required Subscriber WeeklyTopSubscriber { get; init; }

    [JsonPropertyName("30day_top_subscriber")]
    public required Subscriber ThirtyDayTopSubscriber { get; init; }

    [JsonPropertyName("session_top_subscriber")]
    public required Subscriber SessionTopSubscriber { get; init; }

    [JsonPropertyName("monthly_top_subscribers")]
    public required IReadOnlyCollection<Subscriber> MonthlyTopSubscribers { get; init; }

    [JsonPropertyName("weekly_top_subscribers")]
    public required IReadOnlyCollection<Subscriber> WeeklyTopSubscribers { get; init; }

    [JsonPropertyName("30day_top_subscribers")]
    public required IReadOnlyCollection<Subscriber> ThirtyDayTopSubscribers { get; init; }

    [JsonPropertyName("session_top_subscribers")]
    public required IReadOnlyCollection<Subscriber> SessionTopSubscribers { get; init; }

    [JsonPropertyName("_id")]
    public required string MessageId { get; init; }

    [JsonPropertyName("priority")]
    public long Priority { get; init; }
}

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public interface IFetchScheduleUrlProvider
    {
        string GetWeeklyScheduleUrl();
        string GetDailyUpdateScheduleUrl();
    }
}
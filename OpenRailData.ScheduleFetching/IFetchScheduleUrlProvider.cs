namespace OpenRailData.ScheduleFetching
{
    public interface IFetchScheduleUrlProvider
    {
        string GetWeeklyScheduleUrl();
        string GetDailyUpdateScheduleUrl();
    }
}
namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public interface IScheduleFileFetcher
    {
        byte[] FetchDailyScheduleUpdateFile();
        byte[] FetchWeeklyScheduleFile();
    }
}
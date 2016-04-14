namespace OpenRailData.ScheduleFetching
{
    public interface IScheduleFileFetcher
    {
        byte[] FetchScheduleFileFromUrl(string url);
    }
}
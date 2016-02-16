namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public interface IScheduleFileFetcher
    {
        byte[] FetchScheduleFileFromUrl(string url);
    }
}
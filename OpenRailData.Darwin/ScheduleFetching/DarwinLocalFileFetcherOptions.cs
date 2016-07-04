namespace OpenRailData.Darwin.ScheduleFetching
{
    public class DarwinLocalFileFetcherOptions : IDarwinScheduleFetcherOptions
    {
        public string DarwinScheduleFilePath { get; set; }

        public string DarwinScheduleFileSuffix { get; set; }
    }
}
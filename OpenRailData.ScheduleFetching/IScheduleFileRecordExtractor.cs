using System.Collections.Generic;

namespace OpenRailData.ScheduleFetching
{
    public interface IScheduleFileRecordExtractor
    {
        IEnumerable<string> ExtractScheduleFileRecords(byte[] scheduleFile);
    }
}
using System.Collections.Generic;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public interface IScheduleFileRecordExtractor
    {
        IEnumerable<string> ExtractScheduleFileRecords(byte[] scheduleFile);
    }
}
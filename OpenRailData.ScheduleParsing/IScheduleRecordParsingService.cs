using System.Collections.Generic;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.ScheduleParsing
{
    public interface IScheduleRecordParsingService
    {
        IEnumerable<IScheduleRecord> ParseScheduleRecords(IEnumerable<string> records);
    }
}
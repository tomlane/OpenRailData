using System.Collections.Generic;
using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleParsing
{
    public interface IScheduleRecordParsingService
    {
        IEnumerable<IScheduleRecord> ParseScheduleRecords(IEnumerable<string> records);
    }
}
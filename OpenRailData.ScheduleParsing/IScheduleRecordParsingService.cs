using System.Collections.Generic;
using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleParsing
{
    public interface IScheduleRecordParsingService
    {
        IScheduleRecord Parse(string record);

        IEnumerable<IScheduleRecord> Parse(IEnumerable<string> records);
    }
}
using System.Collections.Generic;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleParsing
{
    public interface IScheduleRecordParsingService
    {
        IScheduleRecord Parse(string record);

        IEnumerable<IScheduleRecord> Parse(IEnumerable<string> records);
    }
}
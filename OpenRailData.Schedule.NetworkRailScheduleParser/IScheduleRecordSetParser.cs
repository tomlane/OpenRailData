using System.Collections.Generic;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public interface IScheduleRecordSetParser
    {
        IEnumerable<IScheduleRecord> ParseScheduleRecordSet(IEnumerable<string> recordsToParse);
    }
}
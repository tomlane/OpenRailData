using System.Collections.Generic;
using OpenRailData.Schedule.Records.NetworkRail;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public interface IScheduleParser
    {
        IList<IScheduleRecord> ParseScheduleFile(IEnumerable<string> recordsToParse);
    }
}
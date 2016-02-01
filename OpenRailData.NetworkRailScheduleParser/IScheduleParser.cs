using System.Collections.Generic;
using OpenRailData.Schedule.Records.NetworkRail;

namespace OpenRailData.NetworkRailScheduleParser
{
    public interface IScheduleParser
    {
        IList<IScheduleRecord> ParseScheduleFile(IEnumerable<string> recordsToParse);
    }
}
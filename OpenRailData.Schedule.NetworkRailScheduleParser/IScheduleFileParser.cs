using System.Collections.Generic;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public interface IScheduleFileParser
    {
        IList<IScheduleRecord> ParseScheduleFile(byte[] scheduleFile);
    }
}
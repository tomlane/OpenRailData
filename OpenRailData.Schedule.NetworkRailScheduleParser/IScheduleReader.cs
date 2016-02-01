using System.Collections.Generic;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public interface IScheduleReader
    {
        IEnumerable<string> ReadSchedule(string filePath);
    }
}
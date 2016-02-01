using System.Collections.Generic;

namespace OpenRailData.NetworkRailScheduleParser
{
    public interface IScheduleReader
    {
        IEnumerable<string> ReadSchedule(string filePath);
    }
}
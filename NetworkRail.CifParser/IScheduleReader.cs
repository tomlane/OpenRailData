using System.Collections.Generic;

namespace NetworkRail.CifParser
{
    public interface IScheduleReader
    {
        IEnumerable<string> ReadSchedule(string filePath);
    }
}
using System;

namespace OpenRailData.Schedule.PropertyParsers.NetworkRail
{
    public interface ITimingAllowanceParser
    {
        TimeSpan? ParseTime(string timeString);
    }
}
using System;

namespace OpenRailData.ScheduleParsing
{
    public interface ITimingAllowanceParser
    {
        TimeSpan ParseTime(string timeString);
    }
}
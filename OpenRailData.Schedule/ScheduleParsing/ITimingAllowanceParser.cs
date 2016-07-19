using System;

namespace OpenRailData.Schedule.ScheduleParsing
{
    public interface ITimingAllowanceParser
    {
        TimeSpan ParseTime(string timeString);
    }
}
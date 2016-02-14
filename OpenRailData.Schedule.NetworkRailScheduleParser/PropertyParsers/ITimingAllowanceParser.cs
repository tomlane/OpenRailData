using System;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers
{
    public interface ITimingAllowanceParser
    {
        TimeSpan ParseTime(string timeString);
    }
}
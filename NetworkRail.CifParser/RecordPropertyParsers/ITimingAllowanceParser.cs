using System;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public interface ITimingAllowanceParser
    {
        TimeSpan? ParseTime(string timeString);
    }
}
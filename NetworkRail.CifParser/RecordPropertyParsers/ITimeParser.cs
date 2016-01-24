using System;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public interface ITimeParser
    {
        TimeSpan? ParseTime(string timeString);
    }
}
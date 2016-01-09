using System;

namespace NetworkRail.CifParser.Parsers
{
    public interface ITimeParser
    {
        TimeSpan? ParseTime(string timeString);
    }
}
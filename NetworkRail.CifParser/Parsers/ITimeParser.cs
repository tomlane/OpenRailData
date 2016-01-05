using System;

namespace NetworkRail.CifParser.Parsers
{
    public interface ITimeParser
    {
        TimeSpan? ParseNullableTime(string timeString);
        TimeSpan ParseTime(string timeString);
    }
}
using System;

namespace NetworkRail.CifParser.Parsers
{
    public interface ILocationTimeParser
    {
        TimeSpan? ParseLocationTime(string locationTime);
    }
}
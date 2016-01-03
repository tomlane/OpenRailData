using System;

namespace NetworkRail.CifParser.Parsers
{
    public interface ITimingAllowanceParser
    {
        TimeSpan? ParseTimingAllowance(string timingAllowance);
    }
}
using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public class RunningDaysParser : IRunningDaysParser
    {
        public Days ParseRunningDays(string runningDays)
        {
            if (runningDays == null)
                throw new ArgumentNullException(nameof(runningDays));

            if (runningDays.Length != 7)
                throw new ArgumentException("Running Days must have a length of 7.");

            Days result = 0;

            if (runningDays.Substring(0, 1).Trim() == "1")
                result = result | Days.Monday;
            if (runningDays.Substring(1, 1).Trim() == "1")
                result = result | Days.Tuesday;
            if (runningDays.Substring(2, 1).Trim() == "1")
                result = result | Days.Wednesday;
            if (runningDays.Substring(3, 1).Trim() == "1")
                result = result | Days.Thursday;
            if (runningDays.Substring(4, 1).Trim() == "1")
                result = result | Days.Friday;
            if (runningDays.Substring(5, 1).Trim() == "1")
                result = result | Days.Saturday;
            if (runningDays.Substring(6, 1).Trim() == "1")
                result = result | Days.Sunday;

            return result;
        }
    }
}
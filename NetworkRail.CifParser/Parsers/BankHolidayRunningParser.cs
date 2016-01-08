using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public class BankHolidayRunningParser : IBankHolidayRunningParser
    {
        public BankHolidayRunning ParseBankHolidayRunning(string runningIndicator)
        {
            if (runningIndicator == null)
                throw new ArgumentNullException(nameof(runningIndicator));

            switch (runningIndicator)
            {
                case "G":
                    return BankHolidayRunning.DoesNotRunGlasgow;
                case "X":
                    return BankHolidayRunning.DoesNotRun;
                default:
                    return BankHolidayRunning.RunsOnBankHoliday;
            }
        }
    }
}
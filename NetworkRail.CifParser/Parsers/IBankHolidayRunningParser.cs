using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public interface IBankHolidayRunningParser
    {
        BankHolidayRunning ParseBankHolidayRunning(string runningIndicator);
    }
}
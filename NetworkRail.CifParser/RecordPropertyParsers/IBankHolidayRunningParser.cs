using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public interface IBankHolidayRunningParser
    {
        BankHolidayRunning ParseBankHolidayRunning(string runningIndicator);
    }
}
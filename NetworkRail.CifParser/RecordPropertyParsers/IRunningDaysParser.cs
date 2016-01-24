using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public interface IRunningDaysParser
    {
        Days ParseRunningDays(string runningDays);
    }
}
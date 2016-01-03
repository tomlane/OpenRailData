using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public interface IRunningDaysParser
    {
        Days ParseRunningDays(string runningDays);
    }
}
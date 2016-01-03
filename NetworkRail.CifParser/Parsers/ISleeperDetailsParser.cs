using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public interface ISleeperDetailsParser
    {
        SleeperDetails ParseTrainSleeperDetails(string sleeperDetails);
    }
}
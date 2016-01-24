using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public interface ISleeperDetailsParser
    {
        SleeperDetails ParseTrainSleeperDetails(string sleeperDetails);
    }
}
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public interface IDateIndicatorParser
    {
        DateIndicator ParseDateIndicator(string dateIndicator);
    }
}
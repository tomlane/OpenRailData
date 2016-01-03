using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public interface IDateIndicatorParser
    {
        DateIndicator ParseDateIndicator(string dateIndicator);
    }
}
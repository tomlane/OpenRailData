using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public interface IStpIndicatorParser
    {
        StpIndicator ParseStpIndicator(string stpIndicator);
    }
}
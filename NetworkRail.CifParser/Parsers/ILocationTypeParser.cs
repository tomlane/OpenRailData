using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public interface ILocationTypeParser
    {
        LocationType ParseLocationType(string locationType);
    }
}
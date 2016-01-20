using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public interface ILocationTypeParser
    {
        LocationType ParseLocationType(string locationType);
    }
}
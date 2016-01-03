using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public interface ILocationActivityParser
    {
        LocationActivity ParseActivity(string activities);
    }
}
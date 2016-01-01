using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.Parsers
{
    public interface ILocationActivityParser
    {
        LocationActivity ParseActivity(string activities);
    }
}
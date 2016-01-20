using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public interface ILocationActivityParser
    {
        LocationActivity ParseActivity(string activities);
    }
}
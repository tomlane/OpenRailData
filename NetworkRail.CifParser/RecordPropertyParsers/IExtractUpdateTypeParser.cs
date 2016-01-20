using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public interface IExtractUpdateTypeParser
    {
        ExtractUpdateType ParseExtractUpdateType(string extractUpdateType);
    }
}
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public interface IExtractUpdateTypeParser
    {
        ExtractUpdateType ParseExtractUpdateType(string extractUpdateType);
    }
}
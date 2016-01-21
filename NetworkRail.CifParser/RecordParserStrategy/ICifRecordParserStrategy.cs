using NetworkRail.CifParser.RecordParsers;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordParserStrategy
{
    public interface ICifRecordParserStrategy
    {
        string RecordTypeKey { get; }
        ICifRecordParser<ICifRecord> RecordParser { get; }
    }
}
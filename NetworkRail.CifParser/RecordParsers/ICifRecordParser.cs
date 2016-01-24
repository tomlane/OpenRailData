using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordParsers
{
    public interface ICifRecordParser
    {
        string RecordKey { get; }

        ICifRecord ParseRecord(string recordString);
    }
}
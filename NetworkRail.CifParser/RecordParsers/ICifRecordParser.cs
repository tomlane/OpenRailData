using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordParsers
{
    public interface ICifRecordParser<T> where T : ICifRecord
    {
        T ParseRecord(string recordString);
    }
}
using NetworkRail.CifParser.RecordParsers;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordBuilders
{
    public interface ICifRecordBuilder<T> where T : ICifRecord
    {
        string RecordTypeKey { get; }
        ICifRecordParser<T> RecordParser { get; } 
    }
}
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordBuilders
{
    public interface ICifRecordBuilder<T> where T : ICifRecord
    {
        T BuildRecord(string recordString);
    }
}
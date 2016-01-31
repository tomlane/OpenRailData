using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.CifRecordParsers
{
    public interface ICifRecordParser
    {
        string RecordKey { get; }

        IScheduleRecord ParseRecord(string recordString);
    }
}
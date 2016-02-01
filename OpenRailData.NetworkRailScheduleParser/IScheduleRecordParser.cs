using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser
{
    public interface IScheduleRecordParser
    {
        string RecordKey { get; }

        IScheduleRecord ParseRecord(string recordString);
    }
}
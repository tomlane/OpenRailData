using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.JsonRecordParsers
{
    public interface IJsonRecordParser
    {
        string RecordKey { get; }

        IScheduleRecord ParseRecord(string recordString);
    }
}
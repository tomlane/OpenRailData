using OpenRailData.Schedule.NetworkRailScheduleParser.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public interface IScheduleRecordParser
    {
        string RecordKey { get; }

        IScheduleRecord ParseRecord(string recordString);
    }
}
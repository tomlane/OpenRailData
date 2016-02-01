using OpenRailData.Schedule.Records.NetworkRail;

namespace OpenRailData.NetworkRailScheduleParser
{
    public interface IScheduleRecordParser
    {
        string RecordKey { get; }

        IScheduleRecord ParseRecord(string recordString);
    }
}
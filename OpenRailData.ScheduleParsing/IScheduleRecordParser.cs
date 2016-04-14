using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.ScheduleParsing
{
    public interface IScheduleRecordParser
    {
        string RecordKey { get; }

        IScheduleRecord ParseRecord(string recordString);
    }
}
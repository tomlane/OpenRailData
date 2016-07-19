using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleParsing
{
    public interface IScheduleRecordParser
    {
        string RecordKey { get; }

        IScheduleRecord ParseRecord(string recordString);
    }
}
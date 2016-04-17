using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleParsing
{
    public interface IScheduleRecordParser
    {
        string RecordKey { get; }

        IScheduleRecord ParseRecord(string recordString);
    }
}
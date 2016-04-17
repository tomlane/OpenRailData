using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleStorage
{
    public interface IScheduleRecordRepository
    {
        void InsertRecord(ScheduleRecord record);

        void AmendRecord(ScheduleRecord record);

        void DeleteRecord(ScheduleRecord record);
    }
}
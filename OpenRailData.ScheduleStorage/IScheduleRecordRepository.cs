using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.ScheduleStorage
{
    public interface IScheduleRecordRepository
    {
        void InsertRecord(ScheduleRecord record);

        void AmendRecord(ScheduleRecord record);

        void DeleteRecord(ScheduleRecord record);
    }
}
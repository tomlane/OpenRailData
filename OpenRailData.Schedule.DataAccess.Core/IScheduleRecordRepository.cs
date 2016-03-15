using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.DataAccess.Core
{
    public interface IScheduleRecordRepository
    {
        void InsertRecord(ScheduleRecord record);

        void AmendRecord(ScheduleRecord record);

        void DeleteRecord(ScheduleRecord record);
    }
}
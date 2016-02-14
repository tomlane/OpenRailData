using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public interface IScheduleRecordRepository : IBaseRepository<ScheduleRecord>
    {
        void InsertRecord(ScheduleRecord record);

        void AmendRecord(ScheduleRecord record);

        void DeleteRecord(ScheduleRecord record);
    }
}
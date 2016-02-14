using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public interface IScheduleLocationRecordRepository : IBaseRepository<ScheduleLocationRecord>
    {
        void SaveRecord(ScheduleLocationRecord record);
    }
}
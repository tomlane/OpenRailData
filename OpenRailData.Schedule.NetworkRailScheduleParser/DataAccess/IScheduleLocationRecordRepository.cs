using System.Collections.Generic;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public interface IScheduleLocationRecordRepository : IBaseRepository<ScheduleLocationRecord>
    {
        void InsertRecords(IEnumerable<ScheduleLocationRecord> records);

        void DeleteRecords(IEnumerable<ScheduleLocationRecord> records);
    }
}
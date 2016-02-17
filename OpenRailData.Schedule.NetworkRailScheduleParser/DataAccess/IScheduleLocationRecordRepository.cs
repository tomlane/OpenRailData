using System.Collections.Generic;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public interface IScheduleLocationRecordRepository
    {
        void InsertRecords(IEnumerable<ScheduleLocationRecord> records);

        void DeleteRecords(IEnumerable<ScheduleLocationRecord> records);
    }
}
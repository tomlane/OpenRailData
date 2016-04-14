using System.Collections.Generic;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.ScheduleStorage
{
    public interface IScheduleLocationRecordRepository
    {
        void InsertRecords(IEnumerable<ScheduleLocationRecord> records);

        void DeleteRecords(IEnumerable<ScheduleLocationRecord> records);
    }
}
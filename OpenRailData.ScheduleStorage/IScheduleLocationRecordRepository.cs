using System.Collections.Generic;
using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleStorage
{
    public interface IScheduleLocationRecordRepository
    {
        void InsertRecords(IEnumerable<ScheduleLocationRecord> records);

        void DeleteRecords(IEnumerable<ScheduleLocationRecord> records);
    }
}
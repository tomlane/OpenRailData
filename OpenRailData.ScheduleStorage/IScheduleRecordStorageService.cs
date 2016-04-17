using System.Collections.Generic;
using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleStorage
{
    public interface IScheduleRecordStorageService
    {
        void StoreScheduleRecords(IEnumerable<IScheduleRecord> records);
    }
}
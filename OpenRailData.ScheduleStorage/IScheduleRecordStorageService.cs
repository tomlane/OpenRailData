using System.Collections.Generic;
using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleStorage
{
    public interface IScheduleRecordStorageService
    {
        void Store(IEnumerable<IScheduleRecord> records);
        void Store(IScheduleRecord record);
    }
}
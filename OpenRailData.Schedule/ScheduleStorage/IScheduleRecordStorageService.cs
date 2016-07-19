using System.Collections.Generic;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleStorage
{
    public interface IScheduleRecordStorageService
    {
        void Store(IEnumerable<IScheduleRecord> records);
        void Store(IScheduleRecord record);
    }
}
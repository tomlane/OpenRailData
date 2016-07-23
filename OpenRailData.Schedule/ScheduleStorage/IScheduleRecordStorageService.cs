using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleStorage
{
    public interface IScheduleRecordStorageService
    {
        Task Store(IEnumerable<IScheduleRecord> records);
        Task Store(IScheduleRecord record);
    }
}
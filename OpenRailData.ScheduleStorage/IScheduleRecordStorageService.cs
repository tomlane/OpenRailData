using System.Collections.Generic;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.ScheduleStorage
{
    public interface IScheduleRecordStorageService
    {
        void StoreScheduleRecords(IList<IScheduleRecord> records);
    }
}
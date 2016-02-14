using System.Collections.Generic;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public interface IScheduleRecordStorer
    {
        void StoreScheduleRecords(IList<IScheduleRecord> recordsToStore);
    }
}
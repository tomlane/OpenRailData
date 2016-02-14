using System.Collections.Generic;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public interface IScheduleManager
    {
        IList<IScheduleRecord> GetDailyUpdateScheduleRecords();
        IList<IScheduleRecord> GetWeeklyScheduleRecords();

        IList<IScheduleRecord> MergeScheduleRecords(IList<IScheduleRecord> scheduleRecords);

        void SaveScheduleRecords(IList<IScheduleRecord> scheduleRecordsToSave);
    }
}
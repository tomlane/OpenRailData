using System.Collections.Generic;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public interface IScheduleManager
    {
        IList<IScheduleRecord> GetDailyUpdateScheduleRecords();
        IList<IScheduleRecord> GetWeeklyScheduleRecords();
        IList<IScheduleRecord> MergeScheduleRecords(IList<IScheduleRecord> scheduleRecords); 
    }
}
using System.Collections.Generic;
using OpenRailData.Schedule.Records.NetworkRail;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public interface IScheduleManager
    {
        IList<IScheduleRecord> ParseScheduleRecords(string scheduleFilePath);
        IList<IScheduleRecord> MergeScheduleRecords(IList<IScheduleRecord> scheduleRecords); 
    }
}
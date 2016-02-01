using System.Collections.Generic;
using OpenRailData.Schedule.Records.NetworkRail;

namespace OpenRailData.Schedule.NetworkRailScheduleParser
{
    public interface IScheduleRecordMerger
    {
        IList<IScheduleRecord> MergeScheduleRecords(IList<IScheduleRecord> scheduleRecords);
    }
}
using System.Collections.Generic;
using OpenRailData.Schedule.Records.NetworkRail;

namespace OpenRailData.NetworkRailScheduleParser
{
    public interface IScheduleRecordMerger
    {
        IList<IScheduleRecord> MergeScheduleRecords(IList<IScheduleRecord> scheduleRecords);
    }
}
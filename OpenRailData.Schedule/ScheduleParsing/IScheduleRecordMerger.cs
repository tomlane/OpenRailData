using System.Collections.Generic;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleParsing
{
    public interface IScheduleRecordMerger
    {
        IEnumerable<IScheduleRecord> MergeScheduleRecords(IEnumerable<IScheduleRecord> scheduleRecords);
    }
}
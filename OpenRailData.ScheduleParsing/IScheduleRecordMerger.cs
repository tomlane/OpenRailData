using System.Collections.Generic;
using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleParsing
{
    public interface IScheduleRecordMerger
    {
        IEnumerable<IScheduleRecord> MergeScheduleRecords(IEnumerable<IScheduleRecord> scheduleRecords);
    }
}
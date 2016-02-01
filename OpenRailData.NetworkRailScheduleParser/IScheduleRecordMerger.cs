using System.Collections.Generic;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser
{
    public interface IScheduleRecordMerger
    {
        IList<IScheduleRecord> MergeScheduleRecords(IList<IScheduleRecord> scheduleRecords);
    }
}
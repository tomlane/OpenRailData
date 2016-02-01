using System.Collections.Generic;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser
{
    public interface IScheduleManager
    {
        IList<IScheduleRecord> ParseScheduleRecords(string scheduleFilePath);
        IList<IScheduleRecord> MergeScheduleRecords(IList<IScheduleRecord> scheduleRecords); 
    }
}
using System.Collections.Generic;

namespace NetworkRail.CifParser.Records
{
    public class ScheduleRecord
    {
        public BasicScheduleRecord Schedule { get; set; } = new BasicScheduleRecord();
        public List<IScheduleRecord> LocationRecords { get; set; } = new List<IScheduleRecord>();
    }
}
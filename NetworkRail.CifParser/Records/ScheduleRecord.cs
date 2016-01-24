using System.Collections.Generic;

namespace NetworkRail.CifParser.Records
{
    public class ScheduleRecord
    {
        public BasicScheduleRecord Schedule { get; set; }
        public List<ICifRecord> LocationRecords { get; set; } 
    }
}
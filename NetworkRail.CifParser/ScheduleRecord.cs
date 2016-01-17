using System.Collections.Generic;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser
{
    public class ScheduleRecord
    {
        public BasicScheduleRecord Schedule { get; set; }
        public List<ICifRecord> LocationRecords { get; set; } 
    }
}
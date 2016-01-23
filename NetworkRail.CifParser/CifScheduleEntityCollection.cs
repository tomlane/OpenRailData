using System.Collections.Generic;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser
{
    public class CifScheduleEntityCollection
    {
        public HeaderRecord HeaderRecord { get; set; }
        public List<AssociationRecord> AssociationRecords { get; set; }
        public List<ScheduleRecord> ScheduleRecords { get; set; }
        public List<TiplocInsertRecord> TiplocInsertAmendRecords { get; set; }
        public List<TiplocDeleteRecord> TiplocDeleteRecords { get; set; } 
    }
}
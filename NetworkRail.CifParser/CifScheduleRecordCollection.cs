﻿using System.Collections.Generic;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser
{
    public class CifScheduleRecordCollection
    {
        public HeaderRecord HeaderRecord { get; set; }
        public List<AssociationRecord> AssociationRecords { get; set; }
        public List<ScheduleRecord> ScheduleRecords { get; set; }
        public List<TiplocInsertAmendRecord> TiplocInsertAmendRecords { get; set; }
        public List<TiplocDeleteRecord> TiplocDeleteRecords { get; set; } 
    }
}
using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Records
{
    public class AssociationRecord : ICifRecord
    {
        public CifRecordType RecordType { get; set; }
        public TransactionType TransactionType { get; set; }
        public string MainTrainUid { get; set; } = string.Empty;
        public string AssocTrainUid { get; set; } = string.Empty;
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public Days AssocDays { get; set; }
        public AssociationCategory Category { get; set; }
        public DateIndicator DateIndicator { get; set; }
        public string Location { get; set; } = string.Empty;
        public string BaseLocationSuffix { get; set; } = string.Empty;
        public string AssocLocationSuffix { get; set; } = string.Empty;
        public string DiagramType { get; set; } = string.Empty;
        public AssociationType AssocType { get; set; }
        public StpIndicator StpIndicator { get; set; }
    }
}
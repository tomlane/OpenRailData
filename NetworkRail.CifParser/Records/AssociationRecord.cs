namespace NetworkRail.CifParser.Records
{
    public class AssociationRecord : ICifRecord
    {
        public string TransactionType { get; set; } = string.Empty;
        public string MainTrainUid { get; set; } = string.Empty;
        public string AssocTrainUid { get; set; } = string.Empty;
        public string DateFrom { get; set; } = string.Empty;
        public string DateTo { get; set; } = string.Empty;
        public string AssocMonday { get; set; } = string.Empty;
        public string AssocTuesday { get; set; } = string.Empty;
        public string AssocWednesday { get; set; } = string.Empty;
        public string AssocThursday { get; set; } = string.Empty;
        public string AssocFriday { get; set; } = string.Empty;
        public string AssocSaturday { get; set; } = string.Empty;
        public string AssocSunday { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string DateIndicator { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string BaseLocationSuffix { get; set; } = string.Empty;
        public string AssocLocationSuffix { get; set; } = string.Empty;
        public string AssocType { get; set; } = string.Empty;
        public string StpIndicator { get; set; } = string.Empty;
        
        public CifRecordType GetRecordType()
        {
            return CifRecordType.Association;
        }
    }
}
namespace NetworkRail.CifParser.Records
{
    public class TiplocInsertAmendRecord : ICifRecord
    {
        public string RecordType { get; set; } = string.Empty;
        public string TiplocCode { get; set; } = string.Empty;
        public string Nlc { get; set; } = string.Empty;
        public string TpsDescription { get; set; } = string.Empty;
        public string Stanox { get; set; } = string.Empty;
        public string Crs { get; set; } = string.Empty;
        public string CapriDescription { get; set; } = string.Empty;
        public string OldTiploc { get; set; } = string.Empty;

        public bool IsAmend => !string.IsNullOrEmpty(OldTiploc);
        
        public CifRecordType GetRecordType()
        {
            if (RecordType == "I")
                return CifRecordType.TiplocInsert;

            if (RecordType == "A" && OldTiploc == string.Empty)
                    return CifRecordType.TiplocAmend;

            return CifRecordType.TiplocAmendOther;

        }
    }
}
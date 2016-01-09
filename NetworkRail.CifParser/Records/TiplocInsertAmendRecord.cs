namespace NetworkRail.CifParser.Records
{
    public class TiplocInsertAmendRecord : ICifRecord
    {
        public CifRecordType RecordIdentity { get; set; }
        public string TiplocCode { get; set; } = string.Empty;
        public string CapitalsIdentification { get; set; } = string.Empty;
        public string Nalco { get; set; } = string.Empty;
        public string Nlc { get; set; } = string.Empty;
        public string TpsDescription { get; set; } = string.Empty;
        public string Stanox { get; set; } = string.Empty;
        public string PoMcbCode { get; set; } = string.Empty;
        public string CrsCode { get; set; } = string.Empty;
        public string CapriDescription { get; set; } = string.Empty;
        public string OldTiploc { get; set; } = string.Empty;

        public bool IsAmend => !string.IsNullOrEmpty(OldTiploc);
    }
}
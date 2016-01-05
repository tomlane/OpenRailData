namespace NetworkRail.CifParser.Records
{
    public class BasicScheduleExtraDetailsRecord : ICifRecord
    {
        public CifRecordType RecordIdentity { get; set; }
        public string UicCode { get; set; } = string.Empty;
        public string AtocCode { get; set; } = string.Empty;
        public string AtsCode { get; set; } = string.Empty;
        public string Rsid { get; set; } = string.Empty;
        public string DataSource { get; set; } = string.Empty;
    }
}
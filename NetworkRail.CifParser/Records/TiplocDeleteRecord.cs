namespace NetworkRail.CifParser.Records
{
    public class TiplocDeleteRecord : ICifRecord
    {
        public CifRecordType RecordIdentity { get; set; }
        public string TiplocCode { get; set; } = string.Empty;
    }
}
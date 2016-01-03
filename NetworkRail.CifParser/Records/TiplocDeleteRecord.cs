namespace NetworkRail.CifParser.Records
{
    public class TiplocDeleteRecord : ICifRecord
    {
        public CifRecordType RecordType { get; set; }
        public string TiplocCode { get; set; } = string.Empty;
    }
}
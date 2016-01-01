namespace NetworkRail.CifParser.Records
{
    public class TiplocDeleteRecord : ICifRecord
    {
        public string TiplocCode { get; set; } = string.Empty;
        
        public CifRecordType GetRecordType()
        {
            return CifRecordType.TiplocDelete;
        }
    }
}
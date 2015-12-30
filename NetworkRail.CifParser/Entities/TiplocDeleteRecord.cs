namespace NetworkRail.CifParser.Entities
{
    public class TiplocDeleteRecord : ICifRecord
    {
        public string TiplocCode { get;  }

        public TiplocDeleteRecord(string record)
        {
            TiplocCode = record.Substring(2, 7);
            TiplocCode = TiplocCode.Trim();
        }

        public CifRecordType GetRecordType()
        {
            return CifRecordType.TiplocDelete;
        }
    }
}
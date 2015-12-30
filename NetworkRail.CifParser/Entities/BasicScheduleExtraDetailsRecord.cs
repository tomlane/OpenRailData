namespace NetworkRail.CifParser.Entities
{
    public class BasicScheduleExtraDetailsRecord : ICifRecord
    {
        public string UicCode { get; set; }
        public string AtocCode { get; set; }
        public string AtsCode { get; set; }
        public string Rsid { get; set; }
        public string DataSource { get; set; }

        public BasicScheduleExtraDetailsRecord(string record)
        {
            UicCode = record.Substring(6, 5);
            AtocCode = record.Substring(11, 2);
            AtsCode = record.Substring(13, 1);
            Rsid = record.Substring(14, 8);
            DataSource = record.Substring(22, 1);

            UicCode = UicCode.Trim();
            AtocCode = AtocCode.Trim();
            AtsCode = AtsCode.Trim();
            Rsid = Rsid.Trim();
            DataSource = DataSource.Trim();
        }

        public CifRecordType GetRecordType()
        {
            return CifRecordType.BasicScheduleExtraDetails;
        }
    }
}
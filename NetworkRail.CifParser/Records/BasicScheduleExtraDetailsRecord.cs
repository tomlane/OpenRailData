namespace NetworkRail.CifParser.Records
{
    public class BasicScheduleExtraDetailsRecord : ICifRecord
    {
        public string UicCode { get; set; } = string.Empty;
        public string AtocCode { get; set; } = string.Empty;
        public string AtsCode { get; set; } = string.Empty;
        public string Rsid { get; set; } = string.Empty;
        public string DataSource { get; set; } = string.Empty;

        public CifRecordType GetRecordType()
        {
            return CifRecordType.BasicScheduleExtraDetails;
        }
    }
}
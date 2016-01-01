namespace NetworkRail.CifParser.Records
{
    public class BasicScheduleRecord : ICifRecord
    {
        public string TransactionType { get; set; } = string.Empty;
        public string Uid { get; set; } = string.Empty;
        public string UniqueId { get; set; } = string.Empty;
        public string DateFrom { get; set; } = string.Empty;
        public string DateTo { get; set; } = string.Empty;
        public string RunsMonday { get; set; } = string.Empty;
        public string RunsTuesday { get; set; } = string.Empty;
        public string RunsWednesday { get; set; } = string.Empty;
        public string RunsThursday { get; set; } = string.Empty;
        public string RunsFriday { get; set; } = string.Empty;
        public string RunsSaturday { get; set; } = string.Empty;
        public string RunsSunday { get; set; } = string.Empty;
        public string BankHoliday { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string TrainIdentity { get; set; } = string.Empty;
        public string HeadCode { get; set; } = string.Empty;
        public string ServiceCode { get; set; } = string.Empty;
        public string PortionId { get; set; } = string.Empty;
        public string PowerType { get; set; } = string.Empty;
        public string TimingLoad { get; set; } = string.Empty;
        public string Speed { get; set; } = string.Empty;
        public string OperatingCharacteristicsString { get; set; } = string.Empty;
        public string TrainClass { get; set; } = string.Empty;
        public string Sleepers { get; set; } = string.Empty;
        public string Reservations { get; set; } = string.Empty;
        public string CateringCode { get; set; } = string.Empty;
        public string ServiceBranding { get; set; } = string.Empty;
        public string StpIndicator { get; set; } = string.Empty;

        public bool Train { get; set; }
        public bool Bus { get; set; }
        public bool Ship { get; set; }
        public bool Passenger { get; set; }

        public string UicCode { get; set; } = string.Empty;
        public string AtocCode { get; set; } = string.Empty;
        public string AtsCode { get; set; } = string.Empty;
        public string Rsid { get; set; } = string.Empty;
        public string DataSource { get; set; } = string.Empty;

        public OperatingCharacteristics OperatingCharacteristics { get; set; } = new OperatingCharacteristics();
        
        public void MergeExtraScheduleDetails(BasicScheduleExtraDetailsRecord extraDetailsRecord)
        {
            UicCode = extraDetailsRecord.UicCode;
            AtocCode = extraDetailsRecord.AtocCode;
            AtsCode = extraDetailsRecord.AtsCode;
            Rsid = extraDetailsRecord.Rsid;
            DataSource = extraDetailsRecord.DataSource;
        }

        public CifRecordType GetRecordType()
        {
            return CifRecordType.BasicSchedule;
        }
    }
}
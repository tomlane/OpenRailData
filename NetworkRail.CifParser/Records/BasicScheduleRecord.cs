using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Records
{
    public class BasicScheduleRecord : ICifRecord
    {
        public CifRecordType RecordIdentity { get; set; }
        public TransactionType TransactionType { get; set; }
        public string TrainUid { get; set; } = string.Empty;
        public string UniqueId { get; set; } = string.Empty;
        public DateTime DateRunsFrom { get; set; }
        public DateTime? DateRunsTo { get; set; }
        public Days RunningDays { get; set; }
        
        public BankHolidayRunning BankHolidayRunning { get; set; }
        public string TrainStatus { get; set; } = string.Empty;
        public string TrainCategory { get; set; } = string.Empty;
        public string TrainIdentity { get; set; } = string.Empty;
        public string HeadCode { get; set; } = string.Empty;
        public string CourseIndicator { get; set; } = string.Empty;
        public string TrainServiceCode { get; set; } = string.Empty;
        public string PortionId { get; set; } = string.Empty;
        public string PowerType { get; set; } = string.Empty;
        public string TimingLoad { get; set; } = string.Empty;
        public string Speed { get; set; } = string.Empty;
        public string OperatingCharacteristicsString { get; set; } = string.Empty;
        public OperatingCharacteristics OperatingCharacteristics { get; set; }
        public SeatingClass SeatingClass { get; set; }
        public SleeperDetails Sleepers { get; set; }
        public ReservationDetails Reservations { get; set; }
        public string ConnectionIndicator { get; set; } = string.Empty;
        public string CateringCode { get; set; } = string.Empty;
        public string ServiceBranding { get; set; } = string.Empty;
        public StpIndicator StpIndicator { get; set; }

        public bool Train { get; set; } = true;
        public bool Bus { get; set; }
        public bool Ship { get; set; }
        public bool Passenger { get; set; }

        public string UicCode { get; set; } = string.Empty;
        public string AtocCode { get; set; } = string.Empty;
        public string AtsCode { get; set; } = string.Empty;
        public string Rsid { get; set; } = string.Empty;
        public string DataSource { get; set; } = string.Empty;
        
        public void MergeExtraScheduleDetails(BasicScheduleExtraDetailsRecord extraDetailsRecord)
        {
            UicCode = extraDetailsRecord.UicCode;
            AtocCode = extraDetailsRecord.AtocCode;
            AtsCode = extraDetailsRecord.AtsCode;
            Rsid = extraDetailsRecord.Rsid;
            DataSource = extraDetailsRecord.DataSource;
        }
    }
}
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Records
{
    public class ChangesEnRouteRecord : ICifRecord
    {
        public CifRecordType RecordIdentity { get; set; }
        public string Tiploc { get; set; } = string.Empty; 
        public string TiplocSuffix { get; set; } = string.Empty; 
        public string Category { get; set; } = string.Empty;
        public string TrainIdentity { get; set; } = string.Empty; 
        public string HeadCode { get; set; } = string.Empty;
        public string CourseIndicator { get; set; } = string.Empty;
        public string ServiceCode { get; set; } = string.Empty;
        public string PortionId { get; set; } = string.Empty; 
        public string PowerType { get; set; } = string.Empty;
        public string TimingLoad { get; set; } = string.Empty;
        public int Speed { get; set; }
        public string OperatingCharacteristics { get; set; } = string.Empty;
        public SeatingClass SeatingClass { get; set; }
        public SleeperDetails Sleepers { get; set; }
        public ReservationDetails Reservations { get; set; }
        public string ConnectionIndicator { get; set; } = string.Empty;
        public string CateringCode { get; set; } = string.Empty;
        public string ServiceBranding { get; set; } = string.Empty;
        public string UicCode { get; set; } = string.Empty;
        public string Rsid { get; set; } = string.Empty;
    }
}
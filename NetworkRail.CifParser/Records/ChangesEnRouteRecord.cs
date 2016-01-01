namespace NetworkRail.CifParser.Records
{
    public class ChangesEnRouteRecord : ICifRecord
    {
        public string Tiploc { get; set; } = string.Empty; 
        public string TiplocSuffix { get; set; } = string.Empty; 
        public string Category { get; set; } = string.Empty;
        public string TrainIdentity { get; set; } = string.Empty; 
        public string HeadCode { get; set; } = string.Empty;
        public string ServiceCode { get; set; } = string.Empty;
        public string PortionId { get; set; } = string.Empty; 
        public string PowerType { get; set; } = string.Empty;
        public string TimingLoad { get; set; } = string.Empty;
        public string Speed { get; set; } = string.Empty;
        public string OperatingCharacteristics { get; set; } = string.Empty;
        public string TrainClass { get; set; } = string.Empty;
        public string Sleepers { get; set; } = string.Empty;
        public string Reservations { get; set; } = string.Empty;
        public string CateringCode { get; set; } = string.Empty;
        public string ServiceBranding { get; set; } = string.Empty;
        public string UicCode { get; set; } = string.Empty;
        public string Rsid { get; set; } = string.Empty;

        public CifRecordType GetRecordType()
        {
            return CifRecordType.ChangesEnRoute;
        }
    }
}
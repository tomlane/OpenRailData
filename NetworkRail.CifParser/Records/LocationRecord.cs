namespace NetworkRail.CifParser.Records
{
    public class LocationRecord : ICifRecord
    {
        public string RecordType { get; set; } = string.Empty;
        public string Tiploc { get; set; } = string.Empty;
        public string TiplocInstance { get; set; } = string.Empty;
        public string Arrival { get; set; } = string.Empty;
        public string PublicArrival { get; set; } = string.Empty;
        public string Departure { get; set; } = string.Empty;
        public string PublicDeparture { get; set; } = string.Empty;
        public string Pass { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty;
        public string Line { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string EngineeringAllowance { get; set; } = string.Empty;
        public string PathingAllowance { get; set; } = string.Empty;
        public string PerformanceAllowance { get; set; } = string.Empty;

        public string ActivityString { get; set; } = string.Empty;
        public LocationActivity Activity { get; set; } = new LocationActivity();

        public string OrderTime { get; set; } = string.Empty;

        public bool PublicCall { get; set; }
        public bool ActualCall { get; set; } 

        public CifRecordType GetRecordType()
        {
            return CifRecordType.Location;
        }
    }
}
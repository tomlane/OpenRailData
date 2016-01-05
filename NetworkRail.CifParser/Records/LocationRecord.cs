using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Records
{
    public class LocationRecord : ICifRecord
    {
        public CifRecordType RecordIdentity { get; set; }
        public LocationType LocationType { get; set; }
        public string Tiploc { get; set; } = string.Empty;
        public string TiplocInstance { get; set; } = string.Empty;
        public TimeSpan? Arrival { get; set; }
        public TimeSpan? PublicArrival { get; set; }
        public TimeSpan? Departure { get; set; }
        public TimeSpan? PublicDeparture { get; set; }
        public TimeSpan? Pass { get; set; }
        public string Platform { get; set; } = string.Empty;
        public string Line { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public TimeSpan? EngineeringAllowance { get; set; }
        public TimeSpan? PathingAllowance { get; set; }
        public TimeSpan? PerformanceAllowance { get; set; }

        public string LocationActivityString { get; set; } = string.Empty;
        public LocationActivity LocationActivity { get; set; }

        public TimeSpan? OrderTime { get; set; }
        
        // lambda expressions?
        public bool PublicCall => LocationActivity.HasFlag(LocationActivity.N) && (PublicArrival != null || PublicDeparture != null);
        public bool ActualCall => Arrival != null || Departure != null;
    }
}
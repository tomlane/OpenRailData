using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Records
{
    public class LocationRecord : ICifRecord
    {
        public CifRecordType RecordIdentity { get; set; }
        public LocationType LocationType { get; set; }
        public string Tiploc { get; set; } = string.Empty;
        public string TiplocSuffix { get; set; } = string.Empty;
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
        
        public bool PublicCall => !LocationActivity.HasFlag(LocationActivity.N) && (PublicArrival != null || PublicDeparture != null);
        public bool ActualCall => Arrival != null || Departure != null;

        public string Location => $"{Tiploc}{TiplocSuffix}";

        protected bool Equals(LocationRecord other)
        {
            return Arrival.Equals(other.Arrival) && 
                Departure.Equals(other.Departure) && 
                EngineeringAllowance.Equals(other.EngineeringAllowance) && 
                string.Equals(Line, other.Line) && 
                LocationActivity == other.LocationActivity && 
                string.Equals(LocationActivityString, other.LocationActivityString) && 
                LocationType == other.LocationType && 
                OrderTime.Equals(other.OrderTime) && 
                Pass.Equals(other.Pass) && 
                string.Equals(Path, other.Path) && 
                PathingAllowance.Equals(other.PathingAllowance) && 
                PerformanceAllowance.Equals(other.PerformanceAllowance) && 
                string.Equals(Platform, other.Platform) && 
                PublicArrival.Equals(other.PublicArrival) && 
                PublicDeparture.Equals(other.PublicDeparture) && 
                RecordIdentity == other.RecordIdentity && 
                string.Equals(Tiploc, other.Tiploc) && 
                string.Equals(TiplocSuffix, other.TiplocSuffix);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;

            return Equals((LocationRecord) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Arrival.GetHashCode();
                hashCode = (hashCode*397) ^ Departure.GetHashCode();
                hashCode = (hashCode*397) ^ EngineeringAllowance.GetHashCode();
                hashCode = (hashCode*397) ^ (Line != null ? Line.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) LocationActivity;
                hashCode = (hashCode*397) ^ (LocationActivityString != null ? LocationActivityString.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) LocationType;
                hashCode = (hashCode*397) ^ OrderTime.GetHashCode();
                hashCode = (hashCode*397) ^ Pass.GetHashCode();
                hashCode = (hashCode*397) ^ (Path != null ? Path.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ PathingAllowance.GetHashCode();
                hashCode = (hashCode*397) ^ PerformanceAllowance.GetHashCode();
                hashCode = (hashCode*397) ^ (Platform != null ? Platform.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ PublicArrival.GetHashCode();
                hashCode = (hashCode*397) ^ PublicDeparture.GetHashCode();
                hashCode = (hashCode*397) ^ (int) RecordIdentity;
                hashCode = (hashCode*397) ^ (Tiploc != null ? Tiploc.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TiplocSuffix != null ? TiplocSuffix.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
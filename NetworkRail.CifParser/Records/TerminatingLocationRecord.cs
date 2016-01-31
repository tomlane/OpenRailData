using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Records
{
    public class TerminatingLocationRecord : IScheduleRecord
    {
        public ScheduleRecordType RecordIdentity { get; } = ScheduleRecordType.TerminatingLocation;
        public string Tiploc { get; set; } = string.Empty;
        public string TiplocSuffix { private get; set; } = string.Empty;
        public string Location => $"{Tiploc}{TiplocSuffix}";
        public string WorkingArrival { get; set; }
        public string PublicArrival { get; set; }
        public string Platform { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string LocationActivityString { get; set; } = string.Empty;
        public LocationActivity LocationActivity { get; set; }

        public string OrderTime { get; set; }

        public bool PublicCall => !LocationActivity.HasFlag(LocationActivity.N) && (PublicArrival != null);
        public bool ActualCall => WorkingArrival != null;
        
        protected bool Equals(TerminatingLocationRecord other)
        {
            return WorkingArrival.Equals(other.WorkingArrival) &&
                LocationActivity == other.LocationActivity &&
                string.Equals(LocationActivityString, other.LocationActivityString) &&
                OrderTime.Equals(other.OrderTime) &&
                string.Equals(Path, other.Path) &&
                string.Equals(Platform, other.Platform) &&
                PublicArrival.Equals(other.PublicArrival) &&
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

            return Equals((TerminatingLocationRecord)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = WorkingArrival.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)LocationActivity;
                hashCode = (hashCode * 397) ^ (LocationActivityString != null ? LocationActivityString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ OrderTime.GetHashCode();
                hashCode = (hashCode * 397) ^ (Path != null ? Path.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Platform != null ? Platform.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PublicArrival.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)RecordIdentity;
                hashCode = (hashCode * 397) ^ (Tiploc != null ? Tiploc.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TiplocSuffix != null ? TiplocSuffix.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
using System;
using OpenRailData.ScheduleRecords.NetworkRail.Enums;

namespace OpenRailData.ScheduleRecords.NetworkRail
{
    public class IntermediateLocationRecord : IScheduleRecord
    {
        public ScheduleRecordType RecordIdentity { get; } = ScheduleRecordType.IntermediateLocation;
        public string Tiploc { get; set; } = string.Empty;
        public string TiplocSuffix { get; set; } = string.Empty;
        public string Location => $"{Tiploc}{TiplocSuffix}";
        public string WorkingArrival { get; set; }
        public string PublicArrival { get; set; }
        public string WorkingDeparture { get; set; }
        public string PublicDeparture { get; set; }
        public string Pass { get; set; }
        public string Platform { get; set; } = string.Empty;
        public string Line { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string LocationActivityString { get; set; } = string.Empty;
        public LocationActivity LocationActivity { get; set; }
        public TimeSpan? EngineeringAllowance { get; set; }
        public TimeSpan? PathingAllowance { get; set; }
        public TimeSpan? PerformanceAllowance { get; set; }

        public string OrderTime { get; set; }

        public bool PublicCall => !LocationActivity.HasFlag(LocationActivity.N) && (PublicArrival != null || PublicDeparture != null);
        public bool ActualCall => WorkingArrival != null || WorkingDeparture != null;

        protected bool Equals(IntermediateLocationRecord other)
        {
            return string.Equals(WorkingArrival, other.WorkingArrival) &&
                string.Equals(WorkingDeparture, other.WorkingDeparture) &&
                EngineeringAllowance.Equals(other.EngineeringAllowance) &&
                string.Equals(Line, other.Line) &&
                LocationActivity == other.LocationActivity &&
                string.Equals(LocationActivityString, other.LocationActivityString) &&
                string.Equals(OrderTime, other.OrderTime) &&
                string.Equals(Pass, other.Pass) &&
                string.Equals(Path, other.Path) &&
                PathingAllowance.Equals(other.PathingAllowance) &&
                PerformanceAllowance.Equals(other.PerformanceAllowance) &&
                string.Equals(Platform, other.Platform) &&
                string.Equals(PublicArrival, other.PublicArrival) &&
                string.Equals(PublicDeparture, other.PublicDeparture) &&
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

            return Equals((IntermediateLocationRecord)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = WorkingArrival.GetHashCode();
                hashCode = (hashCode * 397) ^ WorkingDeparture.GetHashCode();
                hashCode = (hashCode * 397) ^ EngineeringAllowance.GetHashCode();
                hashCode = (hashCode * 397) ^ (Line != null ? Line.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)LocationActivity;
                hashCode = (hashCode * 397) ^ (LocationActivityString != null ? LocationActivityString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ OrderTime.GetHashCode();
                hashCode = (hashCode * 397) ^ Pass.GetHashCode();
                hashCode = (hashCode * 397) ^ (Path != null ? Path.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PathingAllowance.GetHashCode();
                hashCode = (hashCode * 397) ^ PerformanceAllowance.GetHashCode();
                hashCode = (hashCode * 397) ^ (Platform != null ? Platform.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ PublicArrival.GetHashCode();
                hashCode = (hashCode * 397) ^ PublicDeparture.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)RecordIdentity;
                hashCode = (hashCode * 397) ^ (Tiploc != null ? Tiploc.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TiplocSuffix != null ? TiplocSuffix.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
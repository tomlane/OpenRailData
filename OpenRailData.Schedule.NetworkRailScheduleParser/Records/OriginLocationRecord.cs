using System;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.Records
{
    public class OriginLocationRecord : IScheduleRecord
    {
        public ScheduleRecordType RecordIdentity { get; set; }
        public string Tiploc { get; set; } = string.Empty;
        public string TiplocSuffix { private get; set; } = string.Empty;
        public string Location => $"{Tiploc}{TiplocSuffix}";
        public string WorkingDeparture { get; set; }
        public string PublicDeparture { get; set; }
        public string Platform { get; set; } = string.Empty;
        public string Line { get; set; } = string.Empty;
        public TimeSpan? EngineeringAllowance { get; set; }
        public TimeSpan? PathingAllowance { get; set; }
        public string LocationActivityString { get; set; } = string.Empty;
        public LocationActivity LocationActivity { get; set; }
        public TimeSpan? PerformanceAllowance { get; set; }

        public string OrderTime { get; set; }
        
        public bool PublicCall => !LocationActivity.HasFlag(LocationActivity.N) && (PublicDeparture != null);
        public bool ActualCall => WorkingDeparture != null;

        protected bool Equals(OriginLocationRecord other)
        {
            return WorkingDeparture.Equals(other.WorkingDeparture) && 
                EngineeringAllowance.Equals(other.EngineeringAllowance) && 
                string.Equals(Line, other.Line) && 
                LocationActivity == other.LocationActivity && 
                string.Equals(LocationActivityString, other.LocationActivityString) && 
                OrderTime.Equals(other.OrderTime) && 
                PathingAllowance.Equals(other.PathingAllowance) && 
                PerformanceAllowance.Equals(other.PerformanceAllowance) && 
                string.Equals(Platform, other.Platform) && 
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

            return Equals((OriginLocationRecord) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = WorkingDeparture.GetHashCode();
                hashCode = (hashCode*397) ^ EngineeringAllowance.GetHashCode();
                hashCode = (hashCode*397) ^ (Line != null ? Line.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) LocationActivity;
                hashCode = (hashCode*397) ^ (LocationActivityString != null ? LocationActivityString.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ OrderTime.GetHashCode();
                hashCode = (hashCode*397) ^ PathingAllowance.GetHashCode();
                hashCode = (hashCode*397) ^ PerformanceAllowance.GetHashCode();
                hashCode = (hashCode*397) ^ (Platform != null ? Platform.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ PublicDeparture.GetHashCode();
                hashCode = (hashCode*397) ^ (int) RecordIdentity;
                hashCode = (hashCode*397) ^ (Tiploc != null ? Tiploc.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TiplocSuffix != null ? TiplocSuffix.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
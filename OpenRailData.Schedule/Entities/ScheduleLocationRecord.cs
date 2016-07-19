using System;
using OpenRailData.Schedule.Entities.Enums;

namespace OpenRailData.Schedule.Entities
{
    public class ScheduleLocationRecord : IScheduleRecord
    {
        /// <summary>
        /// Schedule record type identity.
        /// </summary>
        public ScheduleRecordType RecordIdentity { get; set; }
        /// <summary>
        /// Tiploc.
        /// </summary>
        public string Tiploc { get; set; } = string.Empty;
        /// <summary>
        /// Tiploc suffix.
        /// </summary>
        public string TiplocSuffix
        { get; set; } = string.Empty;
        /// <summary>
        /// Location.
        /// </summary>
        public string Location => $"{Tiploc}{TiplocSuffix}";
        /// <summary>
        /// Working arrival.
        /// </summary>
        public string WorkingArrival { get; set; } = string.Empty;
        /// <summary>
        /// Public passenger arrival.
        /// </summary>
        public string PublicArrival { get; set; } = string.Empty;
        /// <summary>
        /// Working departure.
        /// </summary>
        public string WorkingDeparture { get; set; } = string.Empty;
        /// <summary>
        /// Public passenger departure.
        /// </summary>
        public string PublicDeparture { get; set; } = string.Empty;
        /// <summary>
        /// Pass time.
        /// </summary>
        public string Pass { get; set; } = string.Empty;
        /// <summary>
        /// Platform.
        /// </summary>
        public string Platform { get; set; } = string.Empty;
        /// <summary>
        /// Line.
        /// </summary>
        public string Line { get; set; } = string.Empty;
        /// <summary>
        /// Path.
        /// </summary>
        public string Path { get; set; } = string.Empty;
        /// <summary>
        /// Engineering allowance.
        /// </summary>
        public TimeSpan EngineeringAllowance { get; set; }
        /// <summary>
        /// Pathing allowance.
        /// </summary>
        public TimeSpan PathingAllowance { get; set; }
        /// <summary>
        /// Location activities in string format.
        /// </summary>
        public string LocationActivityString { get; set; } = string.Empty;
        /// <summary>
        /// Location activities.
        /// </summary>
        public LocationActivity LocationActivity { get; set; } = 0;
        /// <summary>
        /// Performance allowance.
        /// </summary>
        public TimeSpan PerformanceAllowance { get; set; }
        /// <summary>
        /// Location order time.
        /// </summary>
        public string OrderTime { get; set; }
        /// <summary>
        /// Whether a location is a public call.
        /// </summary>
        public bool PublicCall => PublicDeparture != null;
        /// <summary>
        /// Whether a location is a stopping/actual call.
        /// </summary>
        public bool ActualCall => WorkingDeparture != null;

        protected bool Equals(ScheduleLocationRecord other)
        {
            return EngineeringAllowance.Equals(other.EngineeringAllowance) && 
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
                string.Equals(TiplocSuffix, other.TiplocSuffix) && 
                string.Equals(WorkingArrival, other.WorkingArrival) && 
                string.Equals(WorkingDeparture, other.WorkingDeparture);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ScheduleLocationRecord) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = EngineeringAllowance.GetHashCode();
                hashCode = (hashCode*397) ^ (Line != null ? Line.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) LocationActivity;
                hashCode = (hashCode*397) ^ (LocationActivityString != null ? LocationActivityString.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (OrderTime != null ? OrderTime.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Pass != null ? Pass.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Path != null ? Path.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ PathingAllowance.GetHashCode();
                hashCode = (hashCode*397) ^ PerformanceAllowance.GetHashCode();
                hashCode = (hashCode*397) ^ (Platform != null ? Platform.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (PublicArrival != null ? PublicArrival.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (PublicDeparture != null ? PublicDeparture.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) RecordIdentity;
                hashCode = (hashCode*397) ^ (Tiploc != null ? Tiploc.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TiplocSuffix != null ? TiplocSuffix.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (WorkingArrival != null ? WorkingArrival.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (WorkingDeparture != null ? WorkingDeparture.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"ActualCall: {ActualCall}, EngineeringAllowance: {EngineeringAllowance}, Line: {Line}, Location: {Location}, LocationActivity: {LocationActivity}, LocationActivityString: {LocationActivityString}, OrderTime: {OrderTime}, Pass: {Pass}, Path: {Path}, PathingAllowance: {PathingAllowance}, PerformanceAllowance: {PerformanceAllowance}, Platform: {Platform}, PublicArrival: {PublicArrival}, PublicCall: {PublicCall}, PublicDeparture: {PublicDeparture}, RecordIdentity: {RecordIdentity}, Tiploc: {Tiploc}, TiplocSuffix: {TiplocSuffix}, WorkingArrival: {WorkingArrival}, WorkingDeparture: {WorkingDeparture}";
        }
    }
}
using System;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities
{
    public class ScheduleLocationRecordEntity : IIdentifyable
    {
        public Guid? Id { get; set; }
        public ScheduleRecordType RecordIdentity { get; set; }
        public string Tiploc { get; set; } = string.Empty;
        public string TiplocSuffix { get; set; } = string.Empty;
        public string Location => $"{Tiploc}{TiplocSuffix}";
        public string WorkingArrival { get; set; } = string.Empty;
        public string PublicArrival { get; set; } = string.Empty;
        public string WorkingDeparture { get; set; } = string.Empty;
        public string PublicDeparture { get; set; } = string.Empty;
        public string Pass { get; set; } = string.Empty;
        public string Platform { get; set; } = string.Empty;
        public string Line { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public TimeSpan EngineeringAllowance { get; set; }
        public TimeSpan PathingAllowance { get; set; }
        public string LocationActivityString { get; set; } = string.Empty;
        public LocationActivity LocationActivity { get; set; } = 0;
        public TimeSpan PerformanceAllowance { get; set; }

        public string OrderTime { get; set; }

        public bool PublicCall => !LocationActivity.HasFlag(LocationActivity.N) && (PublicDeparture != null);
        public bool ActualCall => WorkingDeparture != null;

        public ScheduleRecordEntity ScheduleRecord { get; set; }

        protected bool Equals(ScheduleLocationRecordEntity other)
        {
            return Id == other.Id &&
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
                string.Equals(TiplocSuffix, other.TiplocSuffix) && 
                string.Equals(WorkingArrival, other.WorkingArrival) && 
                string.Equals(WorkingDeparture, other.WorkingDeparture);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ScheduleLocationRecordEntity) obj);
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
            return $"ActualCall: {ActualCall}, EngineeringAllowance: {EngineeringAllowance}, Id: {Id}, Line: {Line}, Location: {Location}, LocationActivity: {LocationActivity}, LocationActivityString: {LocationActivityString}, OrderTime: {OrderTime}, Pass: {Pass}, Path: {Path}, PathingAllowance: {PathingAllowance}, PerformanceAllowance: {PerformanceAllowance}, Platform: {Platform}, PublicArrival: {PublicArrival}, PublicCall: {PublicCall}, PublicDeparture: {PublicDeparture}, RecordIdentity: {RecordIdentity}, Tiploc: {Tiploc}, TiplocSuffix: {TiplocSuffix}, WorkingArrival: {WorkingArrival}, WorkingDeparture: {WorkingDeparture}";
        }
    }
}
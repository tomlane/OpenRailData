using System;
using System.Collections.Generic;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities
{
    public class ScheduleRecordEntity : IIdentifyable
    {
        public Guid? Id { get; set; }
        public ScheduleRecordType RecordIdentity { get; set; }
        public string TrainUid { get; set; } = string.Empty;
        public string UniqueId { get; set; } = string.Empty;
        public DateTime DateRunsFrom { get; set; }
        public DateTime? DateRunsTo { get; set; }
        public Days RunningDays { get; set; }
        
        public BankHolidayRunning BankHolidayRunning { get; set; }
        public string TrainStatus { get; set; } = string.Empty;
        public string TrainCategory { get; set; } = string.Empty;
        public string TrainIdentity { get; set; } = string.Empty;
        public string HeadCode { get; set; } = string.Empty;
        public string CourseIndicator { get; set; } = string.Empty;
        public string TrainServiceCode { get; set; } = string.Empty;
        public string PortionId { get; set; } = string.Empty;
        public PowerType PowerType { get; set; }
        public string TimingLoad { get; set; } = string.Empty;
        public int Speed { get; set; }
        public string OperatingCharacteristicsString { get; set; } = string.Empty;
        public OperatingCharacteristics OperatingCharacteristics { get; set; }
        public SeatingClass SeatingClass { get; set; }
        public SleeperDetails Sleepers { get; set; }
        public ReservationDetails Reservations { get; set; }
        public string ConnectionIndicator { get; set; } = string.Empty;
        public CateringCode CateringCode { get; set; }
        public ServiceBranding ServiceBranding { get; set; }
        public StpIndicator StpIndicator { get; set; }

        public ServiceTypeFlags ServiceTypeFlags { get; set; } = ServiceTypeFlags.Train;

        public string UicCode { get; set; } = string.Empty;
        public string AtocCode { get; set; } = string.Empty;
        public string AtsCode { get; set; } = string.Empty;
        public string Rsid { get; set; } = string.Empty;
        public string DataSource { get; set; } = string.Empty;

        public List<ScheduleLocationRecordEntity> ScheduleLocations { get; set; } = new List<ScheduleLocationRecordEntity>();
        
        protected bool Equals(ScheduleRecordEntity other)
        {
            return Id == other.Id &&
                string.Equals(AtocCode, other.AtocCode) && 
                string.Equals(AtsCode, other.AtsCode) && 
                BankHolidayRunning == other.BankHolidayRunning && 
                CateringCode == other.CateringCode && 
                string.Equals(ConnectionIndicator, other.ConnectionIndicator) && 
                string.Equals(CourseIndicator, other.CourseIndicator) && 
                string.Equals(DataSource, other.DataSource) && 
                DateRunsFrom.Equals(other.DateRunsFrom) && 
                DateRunsTo.Equals(other.DateRunsTo) && 
                string.Equals(HeadCode, other.HeadCode) && 
                OperatingCharacteristics == other.OperatingCharacteristics && 
                string.Equals(OperatingCharacteristicsString, other.OperatingCharacteristicsString) && 
                string.Equals(PortionId, other.PortionId) && 
                PowerType == other.PowerType && 
                RecordIdentity == other.RecordIdentity && 
                Reservations == other.Reservations && 
                string.Equals(Rsid, other.Rsid) && 
                RunningDays == other.RunningDays && 
                Equals(ScheduleLocations, other.ScheduleLocations) && 
                SeatingClass == other.SeatingClass && 
                ServiceBranding == other.ServiceBranding && 
                ServiceTypeFlags == other.ServiceTypeFlags && 
                Sleepers == other.Sleepers && 
                Speed == other.Speed && 
                StpIndicator == other.StpIndicator && 
                string.Equals(TimingLoad, other.TimingLoad) && 
                string.Equals(TrainCategory, other.TrainCategory) && 
                string.Equals(TrainIdentity, other.TrainIdentity) && 
                string.Equals(TrainServiceCode, other.TrainServiceCode) && 
                string.Equals(TrainStatus, other.TrainStatus) && 
                string.Equals(TrainUid, other.TrainUid) && 
                string.Equals(UicCode, other.UicCode) && 
                string.Equals(UniqueId, other.UniqueId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ScheduleRecordEntity) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (AtocCode != null ? AtocCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (AtsCode != null ? AtsCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) BankHolidayRunning;
                hashCode = (hashCode*397) ^ (int) CateringCode;
                hashCode = (hashCode*397) ^ (ConnectionIndicator != null ? ConnectionIndicator.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CourseIndicator != null ? CourseIndicator.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (DataSource != null ? DataSource.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ DateRunsFrom.GetHashCode();
                hashCode = (hashCode*397) ^ DateRunsTo.GetHashCode();
                hashCode = (hashCode*397) ^ (HeadCode != null ? HeadCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) OperatingCharacteristics;
                hashCode = (hashCode*397) ^ (OperatingCharacteristicsString != null ? OperatingCharacteristicsString.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (PortionId != null ? PortionId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) PowerType;
                hashCode = (hashCode*397) ^ (int) RecordIdentity;
                hashCode = (hashCode*397) ^ (int) Reservations;
                hashCode = (hashCode*397) ^ (Rsid != null ? Rsid.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) RunningDays;
                hashCode = (hashCode*397) ^ (ScheduleLocations != null ? ScheduleLocations.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) SeatingClass;
                hashCode = (hashCode*397) ^ (int) ServiceBranding;
                hashCode = (hashCode*397) ^ (int) ServiceTypeFlags;
                hashCode = (hashCode*397) ^ (int) Sleepers;
                hashCode = (hashCode*397) ^ Speed;
                hashCode = (hashCode*397) ^ (int) StpIndicator;
                hashCode = (hashCode*397) ^ (TimingLoad != null ? TimingLoad.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TrainCategory != null ? TrainCategory.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TrainIdentity != null ? TrainIdentity.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TrainServiceCode != null ? TrainServiceCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TrainStatus != null ? TrainStatus.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TrainUid != null ? TrainUid.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (UicCode != null ? UicCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (UniqueId != null ? UniqueId.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"Id: {Id}, RecordIdentity: {RecordIdentity}, TrainUid: {TrainUid}, UniqueId: {UniqueId}, DateRunsFrom: {DateRunsFrom}, DateRunsTo: {DateRunsTo}, RunningDays: {RunningDays}, BankHolidayRunning: {BankHolidayRunning}, TrainStatus: {TrainStatus}, TrainCategory: {TrainCategory}, TrainIdentity: {TrainIdentity}, HeadCode: {HeadCode}, CourseIndicator: {CourseIndicator}, TrainServiceCode: {TrainServiceCode}, PortionId: {PortionId}, PowerType: {PowerType}, TimingLoad: {TimingLoad}, Speed: {Speed}, OperatingCharacteristicsString: {OperatingCharacteristicsString}, OperatingCharacteristics: {OperatingCharacteristics}, SeatingClass: {SeatingClass}, Sleepers: {Sleepers}, Reservations: {Reservations}, ConnectionIndicator: {ConnectionIndicator}, CateringCode: {CateringCode}, ServiceBranding: {ServiceBranding}, StpIndicator: {StpIndicator}, ServiceTypeFlags: {ServiceTypeFlags}, UicCode: {UicCode}, AtocCode: {AtocCode}, AtsCode: {AtsCode}, Rsid: {Rsid}, DataSource: {DataSource}, ScheduleLocations: {ScheduleLocations}";
        }
    }
}
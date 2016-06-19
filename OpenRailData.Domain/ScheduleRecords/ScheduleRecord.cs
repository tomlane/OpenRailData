using System;
using System.Collections.Generic;
using System.Linq;
using OpenRailData.Domain.ScheduleRecords.Enums;

namespace OpenRailData.Domain.ScheduleRecords
{
    public class ScheduleRecord : IScheduleRecord
    {
        /// <summary>
        /// Schedule record type identity.
        /// </summary>
        public ScheduleRecordType RecordIdentity { get; set; }
        /// <summary>
        /// Train uid.
        /// </summary>
        public string TrainUid { get; set; } = string.Empty;
        /// <summary>
        /// Unique record id. Can be used for searches.
        /// </summary>
        public string UniqueId { get; set; } = string.Empty;
        /// <summary>
        /// Schedule start date.
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Schedule end date.
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Schedule running days.
        /// </summary>
        public Days RunningDays { get; set; }
        /// <summary>
        /// Bank holiday running.
        /// </summary>
        public BankHolidayRunning BankHolidayRunning { get; set; } = BankHolidayRunning.X;
        /// <summary>
        /// Train status.
        /// </summary>
        public string TrainStatus { get; set; } = string.Empty;
        /// <summary>
        /// Train category.
        /// </summary>
        public string TrainCategory { get; set; } = string.Empty;
        /// <summary>
        /// Train identity.
        /// </summary>
        public string TrainIdentity { get; set; } = string.Empty;
        /// <summary>
        /// Headcode.
        /// </summary>
        public string HeadCode { get; set; } = string.Empty;
        /// <summary>
        /// Course indicator.
        /// </summary>
        public string CourseIndicator { get; set; } = string.Empty;
        /// <summary>
        /// Train service code.
        /// </summary>
        public string TrainServiceCode { get; set; } = string.Empty;
        /// <summary>
        /// Portion Id.
        /// </summary>
        public string PortionId { get; set; } = string.Empty;
        /// <summary>
        /// Power type.
        /// </summary>
        public PowerType PowerType { get; set; } = PowerType.None;
        /// <summary>
        /// Timing load.
        /// </summary>
        public string TimingLoad { get; set; } = string.Empty;
        /// <summary>
        /// Speed.
        /// </summary>
        public int Speed { get; set; }
        /// <summary>
        /// Operating characteristics in string format.
        /// </summary>
        public string OperatingCharacteristicsString { get; set; } = string.Empty;
        /// <summary>
        /// Operating characteristics.
        /// </summary>
        public OperatingCharacteristics OperatingCharacteristics { get; set; }
        /// <summary>
        /// Seating class.
        /// </summary>
        public SeatingClass SeatingClass { get; set; } = SeatingClass.B;
        /// <summary>
        /// Sleepers.
        /// </summary>
        public SleeperDetails Sleepers { get; set; } = SleeperDetails.NotAvailable;
        /// <summary>
        /// Reservations.
        /// </summary>
        public ReservationDetails Reservations { get; set; }
        /// <summary>
        /// Connection indicator.
        /// </summary>
        public string ConnectionIndicator { get; set; } = string.Empty;
        /// <summary>
        /// Catering code.
        /// </summary>
        public CateringCode CateringCode { get; set; } = CateringCode.None;
        /// <summary>
        /// Service branding.
        /// </summary>
        public ServiceBranding ServiceBranding { get; set; } = ServiceBranding.None;
        /// <summary>
        /// Stp indicator.
        /// </summary>
        public StpIndicator StpIndicator { get; set; }
        /// <summary>
        /// Service type flags.
        /// </summary>
        public ServiceTypeFlags ServiceTypeFlags { get; set; } = 0;
        /// <summary>
        /// Uic code.
        /// </summary>
        public string UicCode { get; set; } = string.Empty;
        /// <summary>
        /// Atoc code.
        /// </summary>
        public string AtocCode { get; set; } = string.Empty;
        /// <summary>
        /// Ats code.
        /// </summary>
        public string AtsCode { get; set; } = string.Empty;
        /// <summary>
        /// Rsid.
        /// </summary>
        public string Rsid { get; set; } = string.Empty;
        /// <summary>
        /// Data source.
        /// </summary>
        public string DataSource { get; set; } = string.Empty;

        /// <summary>
        /// Schedule locations.
        /// </summary>
        public List<ScheduleLocationRecord> ScheduleLocations { get; set; } = new List<ScheduleLocationRecord>();
        
        public void MergeExtraScheduleDetails(BasicScheduleExtraDetailsRecord extraDetailsRecord)
        {
            if (extraDetailsRecord == null)
                throw new ArgumentNullException(nameof(extraDetailsRecord));

            UicCode = extraDetailsRecord.UicCode;
            AtocCode = extraDetailsRecord.AtocCode;
            AtsCode = extraDetailsRecord.AtsCode;
            Rsid = extraDetailsRecord.Rsid;
            DataSource = extraDetailsRecord.DataSource;
        }

        protected bool Equals(ScheduleRecord other)
        {
            return string.Equals(AtocCode, other.AtocCode) && 
                string.Equals(AtsCode, other.AtsCode) && 
                BankHolidayRunning == other.BankHolidayRunning && 
                CateringCode == other.CateringCode && 
                string.Equals(ConnectionIndicator, other.ConnectionIndicator) && 
                string.Equals(CourseIndicator, other.CourseIndicator) && 
                string.Equals(DataSource, other.DataSource) && 
                StartDate.Equals(other.StartDate) && 
                EndDate.Equals(other.EndDate) && 
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
                string.Equals(UniqueId, other.UniqueId)
                && ScheduleLocations.SequenceEqual(other.ScheduleLocations);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ScheduleRecord) obj);
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
                hashCode = (hashCode*397) ^ StartDate.GetHashCode();
                hashCode = (hashCode*397) ^ EndDate.GetHashCode();
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
            return $"RecordIdentity: {RecordIdentity}, TrainUid: {TrainUid}, UniqueId: {UniqueId}, DateRunsFrom: {StartDate}, DateRunsTo: {EndDate}, RunningDays: {RunningDays}, BankHolidayRunning: {BankHolidayRunning}, TrainStatus: {TrainStatus}, TrainCategory: {TrainCategory}, TrainIdentity: {TrainIdentity}, HeadCode: {HeadCode}, CourseIndicator: {CourseIndicator}, TrainServiceCode: {TrainServiceCode}, PortionId: {PortionId}, PowerType: {PowerType}, TimingLoad: {TimingLoad}, Speed: {Speed}, OperatingCharacteristicsString: {OperatingCharacteristicsString}, OperatingCharacteristics: {OperatingCharacteristics}, SeatingClass: {SeatingClass}, Sleepers: {Sleepers}, Reservations: {Reservations}, ConnectionIndicator: {ConnectionIndicator}, CateringCode: {CateringCode}, ServiceBranding: {ServiceBranding}, StpIndicator: {StpIndicator}, ServiceTypeFlags: {ServiceTypeFlags}, UicCode: {UicCode}, AtocCode: {AtocCode}, AtsCode: {AtsCode}, Rsid: {Rsid}, DataSource: {DataSource}, ScheduleLocations: {ScheduleLocations}";
        }
    }
}
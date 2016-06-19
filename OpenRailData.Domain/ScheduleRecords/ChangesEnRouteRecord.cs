using OpenRailData.Domain.ScheduleRecords.Enums;

namespace OpenRailData.Domain.ScheduleRecords
{
    public class ChangesEnRouteRecord : IScheduleRecord
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
        public string TiplocSuffix { get; set; } = string.Empty; 
        /// <summary>
        /// Category.
        /// </summary>
        public string Category { get; set; } = string.Empty;
        /// <summary>
        /// Train identity.
        /// </summary>
        public string TrainIdentity { get; set; } = string.Empty; 
        /// <summary>
        /// Head code.
        /// </summary>
        public string HeadCode { get; set; } = string.Empty;
        /// <summary>
        /// Course indicator.
        /// </summary>
        public string CourseIndicator { get; set; } = string.Empty;
        /// <summary>
        /// Service code.
        /// </summary>
        public string ServiceCode { get; set; } = string.Empty;
        /// <summary>
        /// Portion Id.
        /// </summary>
        public string PortionId { get; set; } = string.Empty; 
        /// <summary>
        /// Power type.
        /// </summary>
        public PowerType PowerType { get; set; }
        /// <summary>
        /// Timing load.
        /// </summary>
        public string TimingLoad { get; set; } = string.Empty;
        /// <summary>
        /// Speed.
        /// </summary>
        public int Speed { get; set; }
        /// <summary>
        /// Operating characteristics.
        /// </summary>
        public string OperatingCharacteristics { get; set; } = string.Empty;
        /// <summary>
        /// Seating class.
        /// </summary>
        public SeatingClass SeatingClass { get; set; }
        /// <summary>
        /// Sleepers.
        /// </summary>
        public SleeperDetails Sleepers { get; set; }
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
        public CateringCode CateringCode { get; set; }
        /// <summary>
        /// Service branding.
        /// </summary>
        public ServiceBranding ServiceBranding { get; set; }
        /// <summary>
        /// Uic code.
        /// </summary>
        public string UicCode { get; set; } = string.Empty;
        /// <summary>
        /// Rsid.
        /// </summary>
        public string Rsid { get; set; } = string.Empty;

        protected bool Equals(ChangesEnRouteRecord other)
        {
            return string.Equals(Category, other.Category) && 
                CateringCode == other.CateringCode && 
                string.Equals(ConnectionIndicator, other.ConnectionIndicator) && 
                string.Equals(CourseIndicator, other.CourseIndicator) && 
                string.Equals(HeadCode, other.HeadCode) && 
                string.Equals(OperatingCharacteristics, other.OperatingCharacteristics) && 
                string.Equals(PortionId, other.PortionId) && 
                PowerType == other.PowerType && 
                RecordIdentity == other.RecordIdentity && 
                Reservations == other.Reservations && 
                string.Equals(Rsid, other.Rsid) && 
                SeatingClass == other.SeatingClass && 
                ServiceBranding == other.ServiceBranding && 
                string.Equals(ServiceCode, other.ServiceCode) && 
                Sleepers == other.Sleepers && 
                Speed == other.Speed && 
                string.Equals(TimingLoad, other.TimingLoad) && 
                string.Equals(Tiploc, other.Tiploc) && 
                string.Equals(TiplocSuffix, other.TiplocSuffix) && 
                string.Equals(TrainIdentity, other.TrainIdentity) && 
                string.Equals(UicCode, other.UicCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;

            return Equals((ChangesEnRouteRecord) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Category != null ? Category.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CateringCode != null ? CateringCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ConnectionIndicator != null ? ConnectionIndicator.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CourseIndicator != null ? CourseIndicator.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (HeadCode != null ? HeadCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (OperatingCharacteristics != null ? OperatingCharacteristics.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (PortionId != null ? PortionId.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (PowerType != null ? PowerType.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) RecordIdentity;
                hashCode = (hashCode*397) ^ (int) Reservations;
                hashCode = (hashCode*397) ^ (Rsid != null ? Rsid.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) SeatingClass;
                hashCode = (hashCode*397) ^ (ServiceBranding != null ? ServiceBranding.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ServiceCode != null ? ServiceCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) Sleepers;
                hashCode = (hashCode*397) ^ Speed;
                hashCode = (hashCode*397) ^ (TimingLoad != null ? TimingLoad.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Tiploc != null ? Tiploc.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TiplocSuffix != null ? TiplocSuffix.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TrainIdentity != null ? TrainIdentity.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (UicCode != null ? UicCode.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"Category: {Category}, CateringCode: {CateringCode}, ConnectionIndicator: {ConnectionIndicator}, CourseIndicator: {CourseIndicator}, HeadCode: {HeadCode}, OperatingCharacteristics: {OperatingCharacteristics}, PortionId: {PortionId}, PowerType: {PowerType}, RecordIdentity: {RecordIdentity}, Reservations: {Reservations}, Rsid: {Rsid}, SeatingClass: {SeatingClass}, ServiceBranding: {ServiceBranding}, ServiceCode: {ServiceCode}, Sleepers: {Sleepers}, Speed: {Speed}, TimingLoad: {TimingLoad}, Tiploc: {Tiploc}, TiplocSuffix: {TiplocSuffix}, TrainIdentity: {TrainIdentity}, UicCode: {UicCode}";
        }
    }
}
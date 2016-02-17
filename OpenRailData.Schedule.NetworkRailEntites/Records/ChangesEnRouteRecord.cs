using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;

namespace OpenRailData.Schedule.NetworkRailEntites.Records
{
    public class ChangesEnRouteRecord : IScheduleRecord
    {
        public int Id { get; set; }
        public ScheduleRecordType RecordIdentity { get; set; }
        public string Tiploc { get; set; } = string.Empty; 
        public string TiplocSuffix { get; set; } = string.Empty; 
        public string Category { get; set; } = string.Empty;
        public string TrainIdentity { get; set; } = string.Empty; 
        public string HeadCode { get; set; } = string.Empty;
        public string CourseIndicator { get; set; } = string.Empty;
        public string ServiceCode { get; set; } = string.Empty;
        public string PortionId { get; set; } = string.Empty; 
        public PowerType PowerType { get; set; }
        public string TimingLoad { get; set; } = string.Empty;
        public int Speed { get; set; }
        public string OperatingCharacteristics { get; set; } = string.Empty;
        public SeatingClass SeatingClass { get; set; }
        public SleeperDetails Sleepers { get; set; }
        public ReservationDetails Reservations { get; set; }
        public string ConnectionIndicator { get; set; } = string.Empty;
        public CateringCode CateringCode { get; set; }
        public ServiceBranding ServiceBranding { get; set; }
        public string UicCode { get; set; } = string.Empty;
        public string Rsid { get; set; } = string.Empty;

        protected bool Equals(ChangesEnRouteRecord other)
        {
            return Id == other.Id &&
                string.Equals(Category, other.Category) && 
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
            return $"Category: {Category}, CateringCode: {CateringCode}, ConnectionIndicator: {ConnectionIndicator}, CourseIndicator: {CourseIndicator}, HeadCode: {HeadCode}, Id: {Id}, OperatingCharacteristics: {OperatingCharacteristics}, PortionId: {PortionId}, PowerType: {PowerType}, RecordIdentity: {RecordIdentity}, Reservations: {Reservations}, Rsid: {Rsid}, SeatingClass: {SeatingClass}, ServiceBranding: {ServiceBranding}, ServiceCode: {ServiceCode}, Sleepers: {Sleepers}, Speed: {Speed}, TimingLoad: {TimingLoad}, Tiploc: {Tiploc}, TiplocSuffix: {TiplocSuffix}, TrainIdentity: {TrainIdentity}, UicCode: {UicCode}";
        }
    }
}
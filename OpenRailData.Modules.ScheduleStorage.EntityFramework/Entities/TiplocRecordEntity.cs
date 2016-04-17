using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities
{
    public class TiplocRecordEntity : IIdentifyable
    {
        public int Id { get; set; }
        public ScheduleRecordType RecordIdentity { get; set; }
        public string TiplocCode { get; set; } = string.Empty;
        public string CapitalsIdentification { get; set; } = string.Empty;
        public string Nalco { get; set; } = string.Empty;
        public string Nlc { get; set; } = string.Empty;
        public string TpsDescription { get; set; } = string.Empty;
        public string Stanox { get; set; } = string.Empty;
        public string PoMcbCode { get; set; } = string.Empty;
        public string CrsCode { get; set; } = string.Empty;
        public string CapriDescription { get; set; } = string.Empty;
        public string OldTiploc { get; set; } = string.Empty;
        public string LocationName { get; set; } = string.Empty;

        protected bool Equals(TiplocRecordEntity other)
        {
            return Id == other.Id &&
                RecordIdentity == other.RecordIdentity && 
                string.Equals(TiplocCode, other.TiplocCode) && 
                string.Equals(CapitalsIdentification, other.CapitalsIdentification) && 
                string.Equals(Nalco, other.Nalco) && 
                string.Equals(Nlc, other.Nlc) && 
                string.Equals(TpsDescription, other.TpsDescription) && 
                string.Equals(Stanox, other.Stanox) && 
                string.Equals(PoMcbCode, other.PoMcbCode) && 
                string.Equals(CrsCode, other.CrsCode) && 
                string.Equals(CapriDescription, other.CapriDescription) && 
                string.Equals(OldTiploc, other.OldTiploc);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TiplocRecordEntity) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) RecordIdentity;
                hashCode = (hashCode*397) ^ (TiplocCode != null ? TiplocCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CapitalsIdentification != null ? CapitalsIdentification.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Nalco != null ? Nalco.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Nlc != null ? Nlc.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (TpsDescription != null ? TpsDescription.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Stanox != null ? Stanox.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (PoMcbCode != null ? PoMcbCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CrsCode != null ? CrsCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CapriDescription != null ? CapriDescription.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (OldTiploc != null ? OldTiploc.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"CapitalsIdentification: {CapitalsIdentification}, CapriDescription: {CapriDescription}, CrsCode: {CrsCode}, Id: {Id}, Nalco: {Nalco}, Nlc: {Nlc}, OldTiploc: {OldTiploc}, PoMcbCode: {PoMcbCode}, RecordIdentity: {RecordIdentity}, Stanox: {Stanox}, TiplocCode: {TiplocCode}, TpsDescription: {TpsDescription}";
        }
    }
}
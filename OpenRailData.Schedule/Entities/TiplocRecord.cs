namespace OpenRailData.Schedule.Entities
{
    public class TiplocRecord : IScheduleRecord
    {
        /// <summary>
        /// Schedule record type identity.
        /// </summary>
        public ScheduleRecordType RecordIdentity { get; set; }
        /// <summary>
        /// Tiploc code.
        /// </summary>
        public string TiplocCode { get; set; } = string.Empty;
        /// <summary>
        /// Capitals identification.
        /// </summary>
        public string CapitalsIdentification { get; set; } = string.Empty;
        /// <summary>
        /// Nalco.
        /// </summary>
        public string Nalco { get; set; } = string.Empty;
        /// <summary>
        /// Nlc.
        /// </summary>
        public string Nlc { get; set; } = string.Empty;
        /// <summary>
        /// Tps description.
        /// </summary>
        public string TpsDescription { get; set; } = string.Empty;
        /// <summary>
        /// Stanox.
        /// </summary>
        public string Stanox { get; set; } = string.Empty;
        /// <summary>
        /// PoMcb code.
        /// </summary>
        public string PoMcbCode { get; set; } = string.Empty;
        /// <summary>
        /// Crs code.
        /// </summary>
        public string CrsCode { get; set; } = string.Empty;
        /// <summary>
        /// Capri description.
        /// </summary>
        public string CapriDescription { get; set; } = string.Empty;
        /// <summary>
        /// Old tiploc code, for when the record has been amended.
        /// </summary>
        public string OldTiploc { get; set; } = string.Empty;
        /// <summary>
        /// Friendly location name.
        /// </summary>
        public string LocationName { get; set; } = string.Empty;

        protected bool Equals(TiplocRecord other)
        {
            return RecordIdentity == other.RecordIdentity && 
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
            if (obj.GetType() != GetType()) return false;
            return Equals((TiplocRecord) obj);
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
            return $"CapitalsIdentification: {CapitalsIdentification}, CapriDescription: {CapriDescription}, CrsCode: {CrsCode}, Nalco: {Nalco}, Nlc: {Nlc}, OldTiploc: {OldTiploc}, PoMcbCode: {PoMcbCode}, RecordIdentity: {RecordIdentity}, Stanox: {Stanox}, TiplocCode: {TiplocCode}, TpsDescription: {TpsDescription}";
        }
    }
}
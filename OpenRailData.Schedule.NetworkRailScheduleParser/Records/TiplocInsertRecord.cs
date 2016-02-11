namespace OpenRailData.Schedule.NetworkRailScheduleParser.Records
{
    public class TiplocInsertRecord : IScheduleRecord
    {
        public ScheduleRecordType RecordIdentity { get; } = ScheduleRecordType.TiplocInsert;
        public string TiplocCode { get; set; } = string.Empty;
        public string CapitalsIdentification { get; set; } = string.Empty;
        public string Nalco { get; set; } = string.Empty;
        public string Nlc { get; set; } = string.Empty;
        public string TpsDescription { get; set; } = string.Empty;
        public string Stanox { get; set; } = string.Empty;
        public string PoMcbCode { get; set; } = string.Empty;
        public string CrsCode { get; set; } = string.Empty;
        public string CapriDescription { get; set; } = string.Empty;

        protected bool Equals(TiplocInsertRecord other)
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
                   string.Equals(CapriDescription, other.CapriDescription);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;

            return Equals((TiplocInsertRecord)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)RecordIdentity;
                hashCode = (hashCode * 397) ^ (TiplocCode != null ? TiplocCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CapitalsIdentification != null ? CapitalsIdentification.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Nalco != null ? Nalco.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Nlc != null ? Nlc.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TpsDescription != null ? TpsDescription.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Stanox != null ? Stanox.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (PoMcbCode != null ? PoMcbCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CrsCode != null ? CrsCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (CapriDescription != null ? CapriDescription.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
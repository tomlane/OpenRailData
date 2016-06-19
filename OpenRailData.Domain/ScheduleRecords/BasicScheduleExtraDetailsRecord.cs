namespace OpenRailData.Domain.ScheduleRecords
{
    public class BasicScheduleExtraDetailsRecord : IScheduleRecord
    {
        /// <summary>
        /// Schedule record type identity.
        /// </summary>
        public ScheduleRecordType RecordIdentity { get; set; }
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

        protected bool Equals(BasicScheduleExtraDetailsRecord other)
        {
            return RecordIdentity == other.RecordIdentity && 
                string.Equals(UicCode, other.UicCode) && 
                string.Equals(AtocCode, other.AtocCode) && 
                string.Equals(AtsCode, other.AtsCode) && 
                string.Equals(Rsid, other.Rsid) && 
                string.Equals(DataSource, other.DataSource);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;

            return Equals((BasicScheduleExtraDetailsRecord) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) RecordIdentity;
                hashCode = (hashCode*397) ^ (UicCode != null ? UicCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (AtocCode != null ? AtocCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (AtsCode != null ? AtsCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Rsid != null ? Rsid.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (DataSource != null ? DataSource.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"RecordIdentity: {RecordIdentity}, UicCode: {UicCode}, AtocCode: {AtocCode}, AtsCode: {AtsCode}, Rsid: {Rsid}, DataSource: {DataSource}";
        }
    }
}
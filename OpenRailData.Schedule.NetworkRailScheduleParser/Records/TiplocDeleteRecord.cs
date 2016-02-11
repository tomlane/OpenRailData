namespace OpenRailData.Schedule.NetworkRailScheduleParser.Records
{
    public class TiplocDeleteRecord : IScheduleRecord
    {
        public ScheduleRecordType RecordIdentity { get; } = ScheduleRecordType.TiplocDelete;
        public string TiplocCode { get; set; } = string.Empty;

        protected bool Equals(TiplocDeleteRecord other)
        {
            return RecordIdentity == other.RecordIdentity && 
                string.Equals(TiplocCode, other.TiplocCode);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;

            return Equals((TiplocDeleteRecord) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) RecordIdentity*397) ^ (TiplocCode != null ? TiplocCode.GetHashCode() : 0);
            }
        }
    }
}
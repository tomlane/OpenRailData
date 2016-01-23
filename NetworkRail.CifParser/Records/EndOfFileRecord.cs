namespace NetworkRail.CifParser.Records
{
    public class EndOfFileRecord : ICifRecord
    {
        public CifRecordType RecordIdentity { get; } = CifRecordType.EndOfFile;

        protected bool Equals(EndOfFileRecord other)
        {
            return RecordIdentity == other.RecordIdentity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;

            return Equals((EndOfFileRecord) obj);
        }

        public override int GetHashCode()
        {
            return (int) RecordIdentity;
        }
    }
}
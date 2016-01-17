namespace NetworkRail.CifParser.Records
{
    public class EndOfFileRecord : ICifRecord
    {
        public CifRecordType RecordIdentity { get; set; } = CifRecordType.EndOfFile;
    }
}
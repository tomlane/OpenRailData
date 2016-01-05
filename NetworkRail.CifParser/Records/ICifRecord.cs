namespace NetworkRail.CifParser.Records
{
    public interface ICifRecord
    {
        CifRecordType RecordIdentity { get; set; }
    }
}
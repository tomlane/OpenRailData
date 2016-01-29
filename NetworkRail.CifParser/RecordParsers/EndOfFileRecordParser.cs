using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordParsers
{
    public class EndOfFileRecordParser : ICifRecordParser
    {
        public string RecordKey { get; } = "ZZ";

        public ICifRecord ParseRecord(string recordString)
        {
            return new EndOfFileRecord();
        }
    }
}
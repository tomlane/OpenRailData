using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.CifRecordParsers
{
    public class EndOfFileRecordParser : IScheduleRecordParser
    {
        public string RecordKey { get; } = "ZZ";

        public IScheduleRecord ParseRecord(string recordString)
        {
            return new EndOfFileRecord();
        }
    }
}
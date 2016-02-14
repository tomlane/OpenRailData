using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordParsers
{
    public class EndOfFileRecordParser : IScheduleRecordParser
    {
        public string RecordKey { get; } = "ZZ";

        public IScheduleRecord ParseRecord(string recordString)
        {
            return new EndOfFileRecord
            {
                RecordIdentity = ScheduleRecordType.ZZ
            };
        }
    }
}
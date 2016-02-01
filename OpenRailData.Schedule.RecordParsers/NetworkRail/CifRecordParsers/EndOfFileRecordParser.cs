using OpenRailData.Schedule.NetworkRailScheduleParser;
using OpenRailData.Schedule.Records.NetworkRail;

namespace OpenRailData.Schedule.RecordParsers.NetworkRail.CifRecordParsers
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
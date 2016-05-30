using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleParsing.Json.ScheduleRecordParsers
{
    public class JsonTiplocRecordParser : IScheduleRecordParser
    {
        public string RecordKey { get; } = "TiplocV1";

        public IScheduleRecord ParseRecord(string recordString)
        {
            throw new System.NotImplementedException();
        }
    }
}
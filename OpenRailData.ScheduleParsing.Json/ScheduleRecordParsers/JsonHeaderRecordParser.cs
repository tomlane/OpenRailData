using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleParsing.Json.ScheduleRecordParsers
{
    public class JsonHeaderRecordParser : IScheduleRecordParser
    {
        public string RecordKey { get; } = "JsonTimetableV1";

        public IScheduleRecord ParseRecord(string recordString)
        {
            throw new System.NotImplementedException();
        }
    }
}
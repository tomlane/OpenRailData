using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleParsing.Json.ScheduleRecordParsers
{
    public class JsonScheduleRecordParser : IScheduleRecordParser
    {
        public string RecordKey { get; } = "JsonScheduleV1";

        public IScheduleRecord ParseRecord(string recordString)
        {
            throw new System.NotImplementedException();
        }
    }
}
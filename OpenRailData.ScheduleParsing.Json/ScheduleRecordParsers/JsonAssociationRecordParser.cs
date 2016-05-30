using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleParsing.Json.ScheduleRecordParsers
{
    public class JsonAssociationRecordParser : IScheduleRecordParser
    {
        public string RecordKey { get; } = "JsonAssociationV1";

        public IScheduleRecord ParseRecord(string recordString)
        {
            throw new System.NotImplementedException();
        }
    }
}
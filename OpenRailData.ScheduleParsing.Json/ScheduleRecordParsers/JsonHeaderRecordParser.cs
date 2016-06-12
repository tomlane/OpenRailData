using System;
using Newtonsoft.Json;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.ScheduleParsing.Json.RawRecords;

namespace OpenRailData.ScheduleParsing.Json.ScheduleRecordParsers
{
    public class JsonHeaderRecordParser : IScheduleRecordParser
    {
        public string RecordKey { get; } = "JsonTimetableV1";

        public IScheduleRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(recordString));

            var deserialziedHeader = JsonConvert.DeserializeObject<DeserializedHeader>(recordString);

            throw new NotImplementedException();
        }
    }
}
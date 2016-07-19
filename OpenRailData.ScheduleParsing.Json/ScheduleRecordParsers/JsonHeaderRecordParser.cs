using System;
using Newtonsoft.Json;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.Entities.Enums;
using OpenRailData.Schedule.ScheduleParsing;
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

            return new HeaderRecord
            {
                RecordIdentity = ScheduleRecordType.HD,
                MainFrameIdentity = deserialziedHeader.Header.Sender.Organisation,
                DateOfExtract = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(deserialziedHeader.Header.Timestamp)).UtcDateTime,
                MainFrameUser = deserialziedHeader.Header.Owner,
                CurrentFileRef = deserialziedHeader.Header.MetaData.Sequence,
                ExtractUpdateType = ExtractUpdateType.F,
                MainFrameExtractDate = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(deserialziedHeader.Header.Timestamp)).UtcDateTime
            };
        }
    }
}
using System;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.Entities.Enums;
using OpenRailData.ScheduleParsing.Json.ScheduleRecordParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    public class TJsonHeaderRecordParser
    {
        private JsonHeaderRecordParser BuildParser()
        {
            return new JsonHeaderRecordParser();
        }

        [Fact]
        public void association_parser_returns_correct_schedule_key()
        {
            var parser = BuildParser();

            Assert.Equal("JsonTimetableV1", parser.RecordKey);
        }

        [Fact]
        public void association_parser_throws_when_argument_is_null()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentException>(() => parser.ParseRecord(null));
            Assert.Throws<ArgumentException>(() => parser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentException>(() => parser.ParseRecord(" \t "));
        }

        [Fact]
        public void association_parser_parses_tiploc_correctly()
        {
            var message = "{\"JsonTimetableV1\":{\"classification\":\"public\",\"timestamp\":1465427154,\"owner\":\"Network Rail\",\"Sender\":{\"organisation\":\"Rockshore\",\"application\":\"NTROD\",\"component\":\"SCHEDULE\"},\"Metadata\":{\"type\":\"full\",\"sequence\":1456}}}";

            var tiploc = new HeaderRecord
            {
                RecordIdentity = ScheduleRecordType.HD,
                MainFrameUser = "Network Rail",
                CurrentFileRef = "1456",
                DateOfExtract = new DateTime(2016, 6, 8, 23, 5, 54),
                MainFrameExtractDate = new DateTime(2016, 6, 8, 23, 5, 54),
                MainFrameIdentity = "Rockshore",
                ExtractUpdateType = ExtractUpdateType.F
            };

            var parser = BuildParser();

            var result = parser.ParseRecord(message);

            Assert.Equal(tiploc, result);
        }
    }
}
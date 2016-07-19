using System;
using OpenRailData.Schedule.Entities;
using OpenRailData.ScheduleParsing.Json.ScheduleRecordParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    public class TJsonTiplocRecordParser
    {
        private JsonTiplocRecordParser BuildParser()
        {
            return new JsonTiplocRecordParser();
        }

        [Fact]
        public void association_parser_returns_correct_schedule_key()
        {
            var parser = BuildParser();

            Assert.Equal("TiplocV1", parser.RecordKey);
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
            var message = "{\"TiplocV1\":{\"transaction_type\":\"Create\",\"tiploc_code\":\"ABDARE\",\"nalco\":\"398200\",\"stanox\":\"78100\",\"crs_code\":\"ABA\",\"description\":\"ABERDARE\",\"tps_description\":\"ABERDARE\"}}";

            var tiploc = new TiplocRecord
            {
                RecordIdentity = ScheduleRecordType.TI,
                TiplocCode = "ABDARE",
                Nalco = "398200",
                Stanox = "78100",
                CrsCode = "ABA",
                CapriDescription = "ABERDARE",
                TpsDescription = "ABERDARE"
            };

            var parser = BuildParser();

            var result = parser.ParseRecord(message);

            Assert.Equal(tiploc, result);
        }
    }
}
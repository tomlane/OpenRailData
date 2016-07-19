using System;
using Moq;
using OpenRailData.Schedule.ScheduleParsing;
using OpenRailData.ScheduleParsing.Json.ScheduleRecordParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    public class TJsonScheduleRecordParser
    {
        private readonly IRecordEnumPropertyParser[] _propertyParsers;
        private readonly Mock<ITimingAllowanceParser> _timingAllowanceParser;

        private JsonScheduleRecordParser BuildParser()
        {
            return new JsonScheduleRecordParser(_propertyParsers, _timingAllowanceParser.Object);
        }

        public TJsonScheduleRecordParser()
        {
            _propertyParsers = new IRecordEnumPropertyParser[0];
            _timingAllowanceParser = new Mock<ITimingAllowanceParser>();
        }

        [Fact]
        public void schedule_parser_throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new JsonScheduleRecordParser(null, _timingAllowanceParser.Object));
            Assert.Throws<ArgumentNullException>(() => new JsonScheduleRecordParser(_propertyParsers, null));
        }

        [Fact]
        public void schedule_parser_returns_correct_schedule_key()
        {
            var parser = BuildParser();

            Assert.Equal("JsonScheduleV1", parser.RecordKey);
        }

        [Fact]
        public void parse_record_throws_when_argument_is_null()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentException>(() => parser.ParseRecord(null));
            Assert.Throws<ArgumentException>(() => parser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentException>(() => parser.ParseRecord(" \t "));
        }
    }
}
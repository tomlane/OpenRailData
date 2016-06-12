using System;
using OpenRailData.ScheduleParsing;
using OpenRailData.ScheduleParsing.Json.ScheduleRecordParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    public class TJsonAssociationRecordParser
    {
        private readonly IRecordEnumPropertyParser[] _propertyParsers;

        public TJsonAssociationRecordParser()
        {
            _propertyParsers = new IRecordEnumPropertyParser[0];
        }

        private JsonAssociationRecordParser BuildParser()
        {
            return new JsonAssociationRecordParser(_propertyParsers);
        }

        [Fact]
        public void association_parser_throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new JsonAssociationRecordParser(null));
        }

        [Fact]
        public void association_parser_returns_correct_schedule_key()
        {
            var parser = BuildParser();

            Assert.Equal("JsonAssociationV1", parser.RecordKey);
        }

        [Fact]
        public void association_parser_throws_when_argument_is_null()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentException>(() => parser.ParseRecord(null));
            Assert.Throws<ArgumentException>(() => parser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentException>(() => parser.ParseRecord(" \t "));
        }
    }
}
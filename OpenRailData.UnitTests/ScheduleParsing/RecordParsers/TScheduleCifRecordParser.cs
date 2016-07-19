using System;
using Moq;
using OpenRailData.Schedule.ScheduleParsing;
using OpenRailData.ScheduleParsing.Cif.RecordParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    
    public class TScheduleCifRecordParser
    {
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static Mock<IDateTimeParser> _dateTimeParser;

        public TScheduleCifRecordParser()
        {
            _enumPropertyParsers = new IRecordEnumPropertyParser[0];
            _dateTimeParser = new Mock<IDateTimeParser>(MockBehavior.Strict);
        }

        private ScheduleCifRecordParser BuildParser()
        {
            return new ScheduleCifRecordParser(_enumPropertyParsers, _dateTimeParser.Object);
        }

        [Fact]
        public void throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new ScheduleCifRecordParser(_enumPropertyParsers, null));
            Assert.Throws<ArgumentNullException>(() => new ScheduleCifRecordParser(null, _dateTimeParser.Object));
        }

        [Fact]
        public void throws_when_argument_is_invalid()
        {
            var recordParser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
        }
    }
}
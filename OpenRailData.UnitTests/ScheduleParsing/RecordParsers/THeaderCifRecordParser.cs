using System;
using Moq;
using OpenRailData.Modules.ScheduleParsing.Cif.RecordParsers;
using OpenRailData.ScheduleParsing;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    
    public class THeaderCifRecordParser
    {
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static Mock<IDateTimeParser> _dateTimeParser;

        public THeaderCifRecordParser()
        {
            _enumPropertyParsers = new IRecordEnumPropertyParser[0];
            _dateTimeParser = new Mock<IDateTimeParser>();
        }
        
        private static HeaderCifRecordParser BuildParser()
        {
            return new HeaderCifRecordParser(_enumPropertyParsers, _dateTimeParser.Object);
        }

        [Fact]
        public void throws_when_dependencies_are_null()
        {
            var enumPropertyParsers = new IRecordEnumPropertyParser[0];
            var datetimeParserMock = new Mock<IDateTimeParser>();

            Assert.Throws<ArgumentNullException>(() => new HeaderCifRecordParser(null, datetimeParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new HeaderCifRecordParser(enumPropertyParsers, null));
        }

        [Fact]
        public void throws_when_argument_is_invalid()
        {
            var recordParser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
        }

        [Fact]
        public void returns_correct_record_key()
        {
            var parser = BuildParser();

            Assert.Equal("HD", parser.RecordKey);
        }

        [Fact]
        public void throws_when_mainframe_identity_is_invalid()
        {
            var recordParser = BuildParser();

            var record = "HD                    3012152116DFROC1EDFROC1DUA301215291216                    ";

            Assert.Throws<InvalidOperationException>(() => recordParser.ParseRecord(record));
        }
    }
}

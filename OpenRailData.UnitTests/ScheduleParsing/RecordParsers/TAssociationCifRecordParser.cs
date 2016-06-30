using System;
using Moq;
using OpenRailData.ScheduleParsing.Cif.RecordParsers;
using OpenRailData.ScheduleParsing;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    
    public class TAssociationCifRecordParser
    {
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static Mock<IDateTimeParser> _dateTimeParser;

        public TAssociationCifRecordParser()
        {
            _enumPropertyParsers = new IRecordEnumPropertyParser[0];
            _dateTimeParser = new Mock<IDateTimeParser>(MockBehavior.Strict);
        }
        
        private static AssociationCifRecordParser BuildParser()
        {
            return new AssociationCifRecordParser(_enumPropertyParsers, _dateTimeParser.Object);
        }

        [Fact]
        public void throws_when_dependencies_are_null()
        {
            var enumRecordParsers = new IRecordEnumPropertyParser[0];
            var dateTimeParserMock = new Mock<IDateTimeParser>();

            Assert.Throws<ArgumentNullException>(() => new AssociationCifRecordParser(null, dateTimeParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new AssociationCifRecordParser(enumRecordParsers, null));
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
        public void returns_correct_property_key()
        {
            var parser = BuildParser();

            Assert.Equal("AA", parser.RecordKey);
        }
    }
}
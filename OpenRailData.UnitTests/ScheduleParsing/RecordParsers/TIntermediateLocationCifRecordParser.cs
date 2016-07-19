using System;
using Moq;
using OpenRailData.Schedule.ScheduleParsing;
using OpenRailData.ScheduleParsing.Cif.RecordParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    
    public class TIntermediateLocationCifRecordParser
    {
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static Mock<ITimingAllowanceParser> _timingAllowanceParser;

        public TIntermediateLocationCifRecordParser()
        {
            _enumPropertyParsers = new IRecordEnumPropertyParser[0];
            _timingAllowanceParser = new Mock<ITimingAllowanceParser>(MockBehavior.Strict);
        }

        private static IntermediateLocationCifRecordParser BuildParser()
        {
            return new IntermediateLocationCifRecordParser(_enumPropertyParsers, _timingAllowanceParser.Object);
        }

        [Fact]
        public void throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new IntermediateLocationCifRecordParser(null, _timingAllowanceParser.Object));
            Assert.Throws<ArgumentNullException>(() => new IntermediateLocationCifRecordParser(_enumPropertyParsers, null));
        }

        [Fact]
        public void throws_when_argument_is_null()
        {
            var recordParser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t "));
        }

        [Fact]
        public void returns_correct_property_key()
        {
            var recordParser = BuildParser();

            Assert.Equal("LI", recordParser.RecordKey);
        }
    }
}
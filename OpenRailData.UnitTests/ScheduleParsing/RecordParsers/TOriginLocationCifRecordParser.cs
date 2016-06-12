using System;
using Moq;
using OpenRailData.Modules.ScheduleParsing.Cif.RecordParsers;
using OpenRailData.ScheduleParsing;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    
    public class TOriginLocationCifRecordParser
    {
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;
        private static Mock<ITimingAllowanceParser> _timingAllowanceParser;

        [Fact]
        public void throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new OriginLocationCifRecordParser(null, _timingAllowanceParser.Object));
            Assert.Throws<ArgumentNullException>(() => new OriginLocationCifRecordParser(_enumPropertyParsers, null));
        }

        public TOriginLocationCifRecordParser()
        {
            _enumPropertyParsers = new IRecordEnumPropertyParser[0];
            _timingAllowanceParser = new Mock<ITimingAllowanceParser>(MockBehavior.Strict);
        }
        
        private static OriginLocationCifRecordParser BuildParser()
        {
            return new OriginLocationCifRecordParser(_enumPropertyParsers, _timingAllowanceParser.Object);
        }

        [Fact]
        public void throws_when_argument_is_null()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseRecord(null));
            Assert.Throws<ArgumentNullException>(() => parser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentNullException>(() => parser.ParseRecord(" \t "));
        }

        [Fact]
        public void returns_correct_record_key()
        {
            var parser = BuildParser();

            Assert.Equal("LO", parser.RecordKey);
        }
    }
}

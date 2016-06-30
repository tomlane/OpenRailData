using System;
using OpenRailData.ScheduleParsing.Cif.RecordParsers;
using OpenRailData.ScheduleParsing;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    
    public class TTerminatingLocationCifRecordParser
    {
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;

        public TTerminatingLocationCifRecordParser()
        {
            _enumPropertyParsers = new IRecordEnumPropertyParser[0];
        }

        private TerminatingLocationCifRecordParser BuildParser()
        {
            return new TerminatingLocationCifRecordParser(_enumPropertyParsers);
        }

        [Fact]
        public void throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new TerminatingLocationCifRecordParser(null));
        }

        [Fact]
        public void returns_correct_record_key()
        {
            var parser = BuildParser();

            Assert.Equal("LT", parser.RecordKey);
        }

        [Fact]
        public void throws_when_argument_is_null()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseRecord(null));
            Assert.Throws<ArgumentNullException>(() => parser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentNullException>(() => parser.ParseRecord(" \t "));
        }
    }
}

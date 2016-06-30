using System;
using OpenRailData.ScheduleParsing.Cif.RecordParsers;
using OpenRailData.ScheduleParsing;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    public class TChangesEnRouteCifRecordParser
    {
        private static IRecordEnumPropertyParser[] _enumPropertyParsers;

        public TChangesEnRouteCifRecordParser()
        {
            _enumPropertyParsers = new IRecordEnumPropertyParser[0];
        }
        
        private static ChangesEnRouteCifRecordParser BuildParser()
        {
            return new ChangesEnRouteCifRecordParser(_enumPropertyParsers);
        }

        [Fact]
        public void returns_correct_property_key()
        {
            var parser = BuildParser();

            Assert.Equal("CR", parser.RecordKey);
        }

        [Fact]
        public void throws_when_dependencies_are_null()
        {
            Assert.Throws<ArgumentNullException>(() => new ChangesEnRouteCifRecordParser(null));
        }

        [Fact]
        public void throws_when_argument_string_is_invalid()
        {
            var recordParser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
        }
    }
}
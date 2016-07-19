using System;
using OpenRailData.Schedule.Entities;
using OpenRailData.ScheduleParsing.Cif.RecordParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    
    public class TTiplocDeleteCifRecordParser
    {
        private static TiplocDeleteCifRecordParser BuildParser()
        {
            return new TiplocDeleteCifRecordParser();
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

            Assert.Equal("TD", parser.RecordKey);
        }

        [Fact]
        public void returns_expected_result()
        {
            var recordParser = BuildParser();
            var recordToParse = "TD1234567                                                                       ";
            var expectedResult = new TiplocRecord
            {
                RecordIdentity = ScheduleRecordType.TD,
                TiplocCode = "1234567"
            };

            var result = recordParser.ParseRecord(recordToParse);
            
            Assert.Equal(expectedResult, result);
        }
    }
}

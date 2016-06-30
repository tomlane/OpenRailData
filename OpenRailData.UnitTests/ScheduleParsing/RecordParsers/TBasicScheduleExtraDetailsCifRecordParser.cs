using System;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.ScheduleParsing.Cif.RecordParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    
    public class TBasicScheduleExtraDetailsCifRecordParser
    {
        private static BasicScheduleExtraDetailsCifRecordParser BuildParser()
        {
            return new BasicScheduleExtraDetailsCifRecordParser();
        }

        [Fact]
        public void throws_when_argument_is_null()
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

            Assert.Equal("BX", parser.RecordKey);
        }

        [Fact]
        public void returns_expected_result()
        {
            var recordParser = BuildParser();
            var recordToParse = "BX         XCY                                                                  ";
            var expectedResult = new BasicScheduleExtraDetailsRecord
            {
                RecordIdentity = ScheduleRecordType.BX,
                AtocCode = "XC",
                AtsCode = "Y",
                DataSource = string.Empty,
                Rsid = string.Empty,
                UicCode = string.Empty
            };

            var result = recordParser.ParseRecord(recordToParse);
            
            Assert.Equal(expectedResult, result);
        }
    }
}
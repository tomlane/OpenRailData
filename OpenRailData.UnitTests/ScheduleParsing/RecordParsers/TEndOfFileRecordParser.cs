using OpenRailData.Schedule.Entities;
using OpenRailData.ScheduleParsing.Cif.RecordParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    
    public class TEndOfFileRecordParser
    {
        private static EndOfFileRecordParser BuildParser()
        {
            return new EndOfFileRecordParser();
        }

        [Fact]
        public void returns_correct_record_key()
        {
            var parser = BuildParser();

            Assert.Equal("ZZ", parser.RecordKey);
        }

        [Fact]
        public void returns_expected_result()
        {
            var recordParser = BuildParser();
            var recordToParse = "ZZ                                                                              ";
            var expectedResult = new EndOfFileRecord
            {
                RecordIdentity = ScheduleRecordType.ZZ
            };

            var result = recordParser.ParseRecord(recordToParse);
            
            Assert.Equal(expectedResult, result);
        }
    }
}
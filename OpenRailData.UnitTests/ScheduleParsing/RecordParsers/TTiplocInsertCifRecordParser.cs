using System;
using OpenRailData.Schedule.Entities;
using OpenRailData.ScheduleParsing.Cif.RecordParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.RecordParsers
{
    
    public class TTiplocInsertCifRecordParser
    {
        private static TiplocInsertCifRecordParser BuildParser()
        {
            return new TiplocInsertCifRecordParser();
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

            Assert.Equal("TI", parser.RecordKey);
        }

        [Fact]
        public void returns_expected_result()
        {
            var recordParser = BuildParser();
            var recordToParse = "TIPURLSGB00537901JPURLEY DOWN SIDING GBRF   87807   0                           ";
            var expectedResult = new TiplocRecord
            {
                RecordIdentity = ScheduleRecordType.TI,
                TiplocCode = "PURLSGB",
                CapitalsIdentification = "00",
                Nalco = "537901",
                Nlc = "J",
                TpsDescription = "PURLEY DOWN SIDING GBRF",
                Stanox = "87807",
                PoMcbCode = "0",
                CrsCode = string.Empty,
                CapriDescription = string.Empty
            };

            var result = recordParser.ParseRecord(recordToParse) as TiplocRecord;
            
            Assert.Equal(expectedResult, result);
        }
    }
}

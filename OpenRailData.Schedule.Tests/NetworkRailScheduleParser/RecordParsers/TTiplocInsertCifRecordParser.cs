using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleParser.RecordParsers;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.RecordParsers
{
    [TestFixture]
    public class TTiplocInsertCifRecordParser
    {
        private static TiplocInsertCifRecordParser BuildParser()
        {
            return new TiplocInsertCifRecordParser();
        }

        [Test]
        public void throws_when_argument_is_invalid()
        {
            var recordParser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
        }

        [Test]
        public void returns_correct_record_key()
        {
            var parser = BuildParser();

            Assert.AreEqual("TI", parser.RecordKey);
        }

        [Test]
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
            
            Assert.AreEqual(expectedResult, result);
        }
    }
}

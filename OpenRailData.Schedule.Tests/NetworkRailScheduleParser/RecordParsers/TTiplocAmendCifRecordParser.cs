using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleParser.RecordParsers;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.RecordParsers
{
    [TestFixture]
    public class TTiplocAmendCifRecordParser
    {
        private static TiplocAmendCifRecordParser BuildParser()
        {
            return new TiplocAmendCifRecordParser();
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
        public void returns_expected_result()
        {
            var recordParser = BuildParser();
            var recordToParse = "TAEBOUCS 08544815BEASTBOURNE C.S.           88253   0XEB                0111193 ";
            var expectedResult = new TiplocRecord
            {
                RecordIdentity = ScheduleRecordType.TA,
                TiplocCode = "0111193",
                CapitalsIdentification = "08",
                Nalco = "544815",
                Nlc = "B",
                TpsDescription = "EASTBOURNE C.S.",
                Stanox = "88253",
                PoMcbCode = "0",
                CrsCode = "XEB",
                CapriDescription = string.Empty,
                OldTiploc = "EBOUCS"
            };

            var result = recordParser.ParseRecord(recordToParse) as TiplocRecord;
            
            Assert.AreEqual(expectedResult, result);
        }
    }
}

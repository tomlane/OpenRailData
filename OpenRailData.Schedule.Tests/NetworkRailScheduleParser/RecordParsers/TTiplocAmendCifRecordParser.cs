using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.RecordParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.RecordParsers
{
    [TestFixture]
    public class TTiplocAmendCifRecordParser
    {
        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var recordParser = new TiplocAmendCifRecordParser();

                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
            }

            [Test]
            public void returns_expected_result()
            {
                var recordParser = new TiplocAmendCifRecordParser();

                var record = "TAEBOUCS 08544815BEASTBOURNE C.S.           88253   0XEB                0111193 ";

                var result = recordParser.ParseRecord(record) as TiplocAmendRecord;

                var expectedResult = new TiplocAmendRecord
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

                Assert.AreEqual(expectedResult, result);

                Assert.IsTrue(result.IsAmend);
            }
        }
    }
}
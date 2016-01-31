using System;
using NetworkRail.CifParser.CifRecordParsers;
using NetworkRail.CifParser.Records;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.CifRecordParsers
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

                string record = "TAEBOUCS 08544815BEASTBOURNE C.S.           88253   0XEB                0111193 ";

                var result = recordParser.ParseRecord(record) as TiplocAmendRecord;

                var expectedResult = new TiplocAmendRecord
                {
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
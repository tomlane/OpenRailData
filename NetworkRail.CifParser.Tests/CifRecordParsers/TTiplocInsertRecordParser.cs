using System;
using NetworkRail.CifParser.CifRecordParsers;
using NetworkRail.CifParser.Records;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.CifRecordParsers
{
    [TestFixture]
    public class TTiplocInsertRecordParser
    {
        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var recordParser = new TiplocInsertRecordParser();

                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
            }

            [Test]
            public void returns_expected_result()
            {
                var recordParser = new TiplocInsertRecordParser();

                string record = "TIPURLSGB00537901JPURLEY DOWN SIDING GBRF   87807   0                           ";

                var result = recordParser.ParseRecord(record) as TiplocInsertRecord;

                var expectedResult = new TiplocInsertRecord
                {
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

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}
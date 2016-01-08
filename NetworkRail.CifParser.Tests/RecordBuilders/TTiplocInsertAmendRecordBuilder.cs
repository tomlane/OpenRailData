using System;
using NetworkRail.CifParser.RecordBuilders;
using NetworkRail.CifParser.Records;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordBuilders
{
    [TestFixture]
    public class TTiplocInsertAmendRecordBuilder
    {
        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var builder = new TiplocInsertAmendRecordBuilder();

                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(null));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(" \t"));
            }

            [Test]
            public void returns_expected_result_with_insert_record()
            {
                var builder = new TiplocInsertAmendRecordBuilder();

                string record = "TIPURLSGB00537901JPURLEY DOWN SIDING GBRF   87807   0                           ";

                var result = builder.BuildRecord(record);

                var expectedResult = new TiplocInsertAmendRecord
                {
                    RecordIdentity = CifRecordType.TiplocInsert,
                    TiplocRecordType = TiplocRecordType.Insert,
                    TiplocCode = "PURLSGB",
                    CapitalsIdentification = "00",
                    Nalco = "537901",
                    Nlc = "J",
                    TpsDescription = "PURLEY DOWN SIDING GBRF",
                    Stanox = "87807",
                    PoMcbCode = "0",
                    CrsCode = string.Empty,
                    CapriDescription = string.Empty,
                    OldTiploc = string.Empty
                };

                Assert.AreEqual(expectedResult.RecordIdentity, result.RecordIdentity);
                Assert.AreEqual(expectedResult.TiplocRecordType, result.TiplocRecordType);
                Assert.AreEqual(expectedResult.TiplocCode, result.TiplocCode);
                Assert.AreEqual(expectedResult.CapitalsIdentification, result.CapitalsIdentification);
                Assert.AreEqual(expectedResult.Nalco, result.Nalco);
                Assert.AreEqual(expectedResult.Nlc, result.Nlc);
                Assert.AreEqual(expectedResult.TpsDescription, result.TpsDescription);
                Assert.AreEqual(expectedResult.Stanox, result.Stanox);
                Assert.AreEqual(expectedResult.PoMcbCode, result.PoMcbCode);
                Assert.AreEqual(expectedResult.CrsCode, result.CrsCode);
                Assert.AreEqual(expectedResult.CapriDescription, result.CapriDescription);
                Assert.AreEqual(expectedResult.OldTiploc, result.OldTiploc);

                Assert.IsFalse(result.IsAmend);
            }

            [Test]
            public void returns_expected_result_with_amend_record()
            {
                var builder = new TiplocInsertAmendRecordBuilder();

                string record = "TAEBOUCS 08544815BEASTBOURNE C.S.           88253   0XEB                0111193 ";

                var result = builder.BuildRecord(record);

                var expectedResult = new TiplocInsertAmendRecord
                {
                    RecordIdentity = CifRecordType.TiplocAmend,
                    TiplocRecordType = TiplocRecordType.Amend,
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

                Assert.AreEqual(expectedResult.RecordIdentity, result.RecordIdentity);
                Assert.AreEqual(expectedResult.TiplocRecordType, result.TiplocRecordType);
                Assert.AreEqual(expectedResult.TiplocCode, result.TiplocCode);
                Assert.AreEqual(expectedResult.CapitalsIdentification, result.CapitalsIdentification);
                Assert.AreEqual(expectedResult.Nalco, result.Nalco);
                Assert.AreEqual(expectedResult.Nlc, result.Nlc);
                Assert.AreEqual(expectedResult.TpsDescription, result.TpsDescription);
                Assert.AreEqual(expectedResult.Stanox, result.Stanox);
                Assert.AreEqual(expectedResult.PoMcbCode, result.PoMcbCode);
                Assert.AreEqual(expectedResult.CrsCode, result.CrsCode);
                Assert.AreEqual(expectedResult.CapriDescription, result.CapriDescription);
                Assert.AreEqual(expectedResult.OldTiploc, result.OldTiploc);

                Assert.IsTrue(result.IsAmend);
            }
        }
    }
}
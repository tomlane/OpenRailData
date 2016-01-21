﻿using System;
using NetworkRail.CifParser.RecordParsers;
using NetworkRail.CifParser.Records;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordParsers
{
    [TestFixture]
    public class TTiplocInsertAmendRecordParser
    {
        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var recordParser = new TiplocInsertAmendRecordParser();

                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
            }

            [Test]
            public void returns_expected_result_with_insert_record()
            {
                var recordParser = new TiplocInsertAmendRecordParser();

                string record = "TIPURLSGB00537901JPURLEY DOWN SIDING GBRF   87807   0                           ";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new TiplocInsertAmendRecord
                {
                    RecordIdentity = CifRecordType.TiplocInsert,
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

                Assert.AreEqual(expectedResult, result);
                
                Assert.IsFalse(result.IsAmend);
            }

            [Test]
            public void returns_expected_result_with_amend_record()
            {
                var recordParser = new TiplocInsertAmendRecordParser();

                string record = "TAEBOUCS 08544815BEASTBOURNE C.S.           88253   0XEB                0111193 ";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new TiplocInsertAmendRecord
                {
                    RecordIdentity = CifRecordType.TiplocAmend,
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
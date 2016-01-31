using System;
using NetworkRail.CifParser.CifRecordParsers;
using NetworkRail.CifParser.Records;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.CifRecordParsers
{
    [TestFixture]
    public class TTiplocDeleteCifRecordParser
    {
        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var recordParser = new TiplocDeleteCifRecordParser();

                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
            }

            [Test]
            public void returns_expected_result()
            {
                var recordParser = new TiplocDeleteCifRecordParser();

                string record = "TD1234567                                                                       ";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new TiplocDeleteRecord
                {
                    TiplocCode = "1234567"
                };

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}
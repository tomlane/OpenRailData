using System;
using NetworkRail.CifParser.RecordParsers;
using NetworkRail.CifParser.Records;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordParsers
{
    [TestFixture]
    public class TTiplocDeleteRecordParser
    {
        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var builder = new TiplocDeleteRecordParser();

                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(null));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => builder.BuildRecord(" \t"));
            }

            [Test]
            public void returns_expected_result()
            {
                var builder = new TiplocDeleteRecordParser();

                string record = "TD1234567                                                                       ";

                var result = builder.BuildRecord(record);

                var expectedResult = new TiplocDeleteRecord
                {
                    RecordIdentity = CifRecordType.TiplocDelete,
                    TiplocCode = "1234567"
                };

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}
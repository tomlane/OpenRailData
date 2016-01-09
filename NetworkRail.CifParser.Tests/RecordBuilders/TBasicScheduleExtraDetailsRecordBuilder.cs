using System;
using NetworkRail.CifParser.RecordBuilders;
using NetworkRail.CifParser.Records;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordBuilders
{
    [TestFixture]
    public class TBasicScheduleExtraDetailsRecordBuilder
    {
        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_null()
            {
                var parser = new BasicScheduleExtraDetailsRecordBuilder();

                Assert.Throws<ArgumentNullException>(() => parser.BuildRecord(null));
                Assert.Throws<ArgumentNullException>(() => parser.BuildRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => parser.BuildRecord(" \t"));
            }

            [Test]
            public void returns_expected_result()
            {
                var parser = new BasicScheduleExtraDetailsRecordBuilder();

                string record = "BX         XCY                                                                  ";

                var result = parser.BuildRecord(record);

                var expectedResult = new BasicScheduleExtraDetailsRecord
                {
                    RecordIdentity = CifRecordType.BasicScheduleExtraDetails,
                    AtocCode = "XC",
                    AtsCode = "Y",
                    DataSource = string.Empty,
                    Rsid = string.Empty,
                    UicCode = string.Empty
                };

                Assert.AreEqual(expectedResult.RecordIdentity, result.RecordIdentity);
                Assert.AreEqual(expectedResult.AtocCode, result.AtocCode);
                Assert.AreEqual(expectedResult.AtsCode, result.AtsCode);
                Assert.AreEqual(expectedResult.DataSource, result.DataSource);
                Assert.AreEqual(expectedResult.Rsid, result.Rsid);
                Assert.AreEqual(expectedResult.UicCode, result.UicCode);
            }
        }
    }
}
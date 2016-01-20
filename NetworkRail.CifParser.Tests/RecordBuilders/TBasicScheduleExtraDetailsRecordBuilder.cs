using System;
using NetworkRail.CifParser.RecordParsers;
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
                var parser = new BasicScheduleExtraDetailsRecordParser();

                Assert.Throws<ArgumentNullException>(() => parser.BuildRecord(null));
                Assert.Throws<ArgumentNullException>(() => parser.BuildRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => parser.BuildRecord(" \t"));
            }

            [Test]
            public void returns_expected_result()
            {
                var parser = new BasicScheduleExtraDetailsRecordParser();

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

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}
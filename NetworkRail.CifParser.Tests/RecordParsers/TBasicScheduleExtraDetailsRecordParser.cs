using System;
using NetworkRail.CifParser.RecordParsers;
using NetworkRail.CifParser.Records;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordParsers
{
    [TestFixture]
    public class TBasicScheduleExtraDetailsRecordParser
    {
        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_null()
            {
                var recordParser = new BasicScheduleExtraDetailsRecordParser();

                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
            }

            [Test]
            public void returns_expected_result()
            {
                var recordParser = new BasicScheduleExtraDetailsRecordParser();

                string record = "BX         XCY                                                                  ";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new BasicScheduleExtraDetailsRecord
                {
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
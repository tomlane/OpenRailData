using System;
using NUnit.Framework;
using OpenRailData.Schedule.RecordParsers.NetworkRail.CifRecordParsers;
using OpenRailData.Schedule.Records.NetworkRail;

namespace OpenRailData.Schedule.Tests.RecordParsers.NetworkRail.CifRecordParsers
{
    [TestFixture]
    public class TBasicScheduleExtraDetailsCifRecordParser
    {
        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_null()
            {
                var recordParser = new BasicScheduleExtraDetailsCifRecordParser();

                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
            }

            [Test]
            public void returns_expected_result()
            {
                var recordParser = new BasicScheduleExtraDetailsCifRecordParser();

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
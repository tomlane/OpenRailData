using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.RecordParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.RecordParsers
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

                var record = "BX         XCY                                                                  ";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new BasicScheduleExtraDetailsRecord
                {
                    RecordIdentity = ScheduleRecordType.BX,
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
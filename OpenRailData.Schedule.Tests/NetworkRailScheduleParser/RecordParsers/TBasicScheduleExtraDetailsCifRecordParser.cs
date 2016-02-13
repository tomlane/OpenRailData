using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.RecordParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.RecordParsers
{
    [TestFixture]
    public class TBasicScheduleExtraDetailsCifRecordParser
    {
        private static BasicScheduleExtraDetailsCifRecordParser BuildParser()
        {
            return new BasicScheduleExtraDetailsCifRecordParser();
        }

        [Test]
        public void throws_when_argument_is_null()
        {
            var recordParser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
            Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
        }

        [Test]
        public void returns_expected_result()
        {
            var recordParser = BuildParser();
            var recordToParse = "BX         XCY                                                                  ";
            var expectedResult = new BasicScheduleExtraDetailsRecord
            {
                RecordIdentity = ScheduleRecordType.BX,
                AtocCode = "XC",
                AtsCode = "Y",
                DataSource = string.Empty,
                Rsid = string.Empty,
                UicCode = string.Empty
            };

            var result = recordParser.ParseRecord(recordToParse);
            
            Assert.AreEqual(expectedResult, result);
        }
    }
}
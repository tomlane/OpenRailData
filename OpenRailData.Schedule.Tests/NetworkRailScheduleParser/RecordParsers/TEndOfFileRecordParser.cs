using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.RecordParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.RecordParsers
{
    [TestFixture]
    public class TEndOfFileRecordParser
    {
        [Test]
        public void returns_expected_result()
        {
            var recordParser = new EndOfFileRecordParser();

            var record = "ZZ                                                                              ";

            var result = recordParser.ParseRecord(record);

            var expectedResult = new EndOfFileRecord();

            Assert.AreEqual(expectedResult, result);
        }
    }
}
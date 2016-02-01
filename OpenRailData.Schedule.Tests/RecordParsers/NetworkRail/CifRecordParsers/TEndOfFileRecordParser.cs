using NUnit.Framework;
using OpenRailData.Schedule.RecordParsers.NetworkRail.CifRecordParsers;
using OpenRailData.Schedule.Records.NetworkRail;

namespace OpenRailData.Schedule.Tests.RecordParsers.NetworkRail.CifRecordParsers
{
    [TestFixture]
    public class TEndOfFileRecordParser
    {
        [Test]
        public void returns_expected_result()
        {
            var recordParser = new EndOfFileRecordParser();

            string record = "ZZ                                                                              ";

            var result = recordParser.ParseRecord(record);

            var expectedResult = new EndOfFileRecord();

            Assert.AreEqual(expectedResult, result);
        }
    }
}
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleParser.RecordParsers;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.RecordParsers
{
    [TestFixture]
    public class TEndOfFileRecordParser
    {
        private static EndOfFileRecordParser BuildParser()
        {
            return new EndOfFileRecordParser();
        }

        [Test]
        public void returns_correct_record_key()
        {
            var parser = BuildParser();

            Assert.AreEqual("ZZ", parser.RecordKey);
        }

        [Test]
        public void returns_expected_result()
        {
            var recordParser = BuildParser();
            var recordToParse = "ZZ                                                                              ";
            var expectedResult = new EndOfFileRecord
            {
                RecordIdentity = ScheduleRecordType.ZZ
            };

            var result = recordParser.ParseRecord(recordToParse);
            
            Assert.AreEqual(expectedResult, result);
        }
    }
}
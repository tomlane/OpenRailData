using NetworkRail.CifParser.CifRecordParsers;
using NetworkRail.CifParser.Records;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.CifRecordParsers
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
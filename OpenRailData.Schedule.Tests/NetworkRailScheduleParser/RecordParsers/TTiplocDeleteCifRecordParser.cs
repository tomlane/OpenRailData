using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.RecordParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.RecordParsers
{
    [TestFixture]
    public class TTiplocDeleteCifRecordParser
    {
        [TestFixture]
        class BuildRecord
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var recordParser = new TiplocDeleteCifRecordParser();

                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(null));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(string.Empty));
                Assert.Throws<ArgumentNullException>(() => recordParser.ParseRecord(" \t"));
            }

            [Test]
            public void returns_expected_result()
            {
                var recordParser = new TiplocDeleteCifRecordParser();

                var record = "TD1234567                                                                       ";

                var result = recordParser.ParseRecord(record);

                var expectedResult = new TiplocDeleteRecord
                {
                    TiplocCode = "1234567"
                };

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}
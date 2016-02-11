using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TBankHolidayRunningParser
    {
        [TestFixture]
        class ParseBankHolidayRunning
        {
            [Test]
            public void throws_when_argument_is_null()
            {
                var parser = new BankHolidayRunningParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            }

            [Test]
            [TestCase("X", BankHolidayRunning.X)]
            [TestCase("G", BankHolidayRunning.G)]
            public void returns_expected_non_running_value(string value, BankHolidayRunning expectedResult)
            {
                var parser = new BankHolidayRunningParser();

                var result = parser.ParseProperty(value);
                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void returns_expected_running_value()
            {
                var parser = new BankHolidayRunningParser();

                var result = parser.ParseProperty(string.Empty);
                Assert.AreEqual(BankHolidayRunning.R, result);
            }
        }
    }
}
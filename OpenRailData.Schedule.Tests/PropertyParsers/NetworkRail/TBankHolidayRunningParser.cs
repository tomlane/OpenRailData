using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.PropertyParsers.NetworkRail
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
            public void returns_expected_non_running_value()
            {
                var parser = new BankHolidayRunningParser();

                var result = parser.ParseProperty("X");
                Assert.AreEqual(BankHolidayRunning.X, result);

                result = parser.ParseProperty("G");
                Assert.AreEqual(BankHolidayRunning.G, result);
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
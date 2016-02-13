using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TRunningDaysParser
    {
        private RunningDaysParser BuildParser()
        {
            return new RunningDaysParser();
        }

        [Test]
        public void throws_when_argument_is_null_or_whitespace()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Test]
        public void throws_when_argument_is_incorrect_length()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentException>(() => parser.ParseProperty("12345678"));
            Assert.Throws<ArgumentException>(() => parser.ParseProperty("123456"));
        }

        [Test]
        public void returns_expected_result_running_all_days()
        {
            var parser = BuildParser();

            var result = parser.ParseProperty("1111111");

            var expectedResult = Days.Monday | Days.Tuesday | Days.Wednesday | Days.Thursday | Days.Friday |
                                 Days.Saturday | Days.Sunday;

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void returns_expected_result_weekdays_only()
        {
            var parser = BuildParser();

            var result = parser.ParseProperty("1111100");

            var expectedResult = Days.Monday | Days.Tuesday | Days.Wednesday | Days.Thursday | Days.Friday;

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void returns_expected_result_weekends_only()
        {
            var parser = BuildParser();

            var result = parser.ParseProperty("0000011");

            var expectedResult = Days.Saturday | Days.Sunday;

            Assert.AreEqual(expectedResult, result);
        }
    }
}
using System;
using NUnit.Framework;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TTimingAllowanceParser
    {
        private TimingAllowanceParser BuildParser()
        {
            return new TimingAllowanceParser();
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" \t ")]
        public void returns_null_when_argument_is_null_or_empty(string value)
        {
            var parser = BuildParser();
            var expectedResult = new TimeSpan(0);

            var result = parser.ParseTime(value);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void returns_zero_span_when_argument_is_four_zeros()
        {
            var parser = BuildParser();

            var result = parser.ParseTime("0000");

            Assert.AreEqual(new TimeSpan(0), result);
        }

        [Test]
        public void returns_expected_result_for_half_time()
        {
            var parser = BuildParser();

            var result = parser.ParseTime("H");
            Assert.AreEqual(TimeSpan.FromSeconds(30), result);

            result = parser.ParseTime("2H");
            Assert.AreEqual(TimeSpan.FromSeconds(150), result);
        }

        [Test]
        public void returns_expected_result_with_white_space()
        {
            var parser = BuildParser();

            var result = parser.ParseTime("1020 ");
            Assert.AreEqual(new TimeSpan(0, 10, 20, 0), result);
        }

        [Test]
        public void returns_expected_result_for_whole_minutes()
        {
            var parser = BuildParser();

            var result = parser.ParseTime("1");
            Assert.AreEqual(TimeSpan.FromMinutes(1), result);

            result = parser.ParseTime("15");
            Assert.AreEqual(TimeSpan.FromMinutes(15), result);
        }

        [Test]
        public void returns_expected_result_for_hours_and_minutes()
        {
            var parser = BuildParser();

            var result = parser.ParseTime("1028");
            Assert.AreEqual(new TimeSpan(0, 10, 28, 0), result);
        }

        [Test]
        [TestCase("Y")]
        [TestCase("XYZ|")]
        public void returns_null_when_argument_is_invalid(string value)
        {
            var parser = BuildParser();
            var expectedResult = new TimeSpan(0);

            var result = parser.ParseTime(value);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
using System;
using OpenRailData.Schedule.ScheduleParsing.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    
    public class TTimingAllowanceParser
    {
        private TimingAllowanceParser BuildParser()
        {
            return new TimingAllowanceParser();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" \t ")]
        public void returns_null_when_argument_is_null_or_empty(string value)
        {
            var parser = BuildParser();
            var expectedResult = new TimeSpan(0);

            var result = parser.ParseTime(value);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void returns_zero_span_when_argument_is_four_zeros()
        {
            var parser = BuildParser();

            var result = parser.ParseTime("0000");

            Assert.Equal(new TimeSpan(0), result);
        }

        [Fact]
        public void returns_expected_result_for_half_time()
        {
            var parser = BuildParser();

            var result = parser.ParseTime("H");
            Assert.Equal(TimeSpan.FromSeconds(30), result);

            result = parser.ParseTime("2H");
            Assert.Equal(TimeSpan.FromSeconds(150), result);
        }

        [Fact]
        public void returns_expected_result_with_white_space()
        {
            var parser = BuildParser();

            var result = parser.ParseTime("1020 ");
            Assert.Equal(new TimeSpan(0, 10, 20, 0), result);
        }

        [Fact]
        public void returns_expected_result_for_whole_minutes()
        {
            var parser = BuildParser();

            var result = parser.ParseTime("1");
            Assert.Equal(TimeSpan.FromMinutes(1), result);

            result = parser.ParseTime("15");
            Assert.Equal(TimeSpan.FromMinutes(15), result);
        }

        [Fact]
        public void returns_expected_result_for_hours_and_minutes()
        {
            var parser = BuildParser();

            var result = parser.ParseTime("1028");
            Assert.Equal(new TimeSpan(0, 10, 28, 0), result);
        }

        [Theory]
        [InlineData("Y")]
        [InlineData("XYZ|")]
        public void returns_null_when_argument_is_invalid(string value)
        {
            var parser = BuildParser();
            var expectedResult = new TimeSpan(0);

            var result = parser.ParseTime(value);

            Assert.Equal(expectedResult, result);
        }
    }
}
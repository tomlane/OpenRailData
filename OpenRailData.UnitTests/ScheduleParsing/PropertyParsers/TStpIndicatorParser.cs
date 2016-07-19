using System;
using OpenRailData.Schedule.Entities.Enums;
using OpenRailData.Schedule.ScheduleParsing.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    
    public class TStpIndicatorParser
    {
        private StpIndicatorParser BuildParser()
        {
            return new StpIndicatorParser();
        }

        [Fact]
        public void throws_when_argument_is_invalid()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(string.Empty));
            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(" \t"));
        }

        [Theory]
        [InlineData("C", StpIndicator.C)]
        [InlineData("N", StpIndicator.N)]
        [InlineData("O", StpIndicator.O)]
        [InlineData("P", StpIndicator.P)]
        public void returns_expected_result_from_argument(string value, StpIndicator expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void throws_when_argument_is_unknown()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentException>(() => parser.ParseProperty("Z"));
        }
    }
}
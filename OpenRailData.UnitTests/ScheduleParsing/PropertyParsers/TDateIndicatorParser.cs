using System;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    
    public class TDateIndicatorParser
    {
        private DateIndicatorParser BuildParser()
        {
            return new DateIndicatorParser();
        }

        [Fact]
        public void throws_when_argument_is_invalid()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Theory]
        [InlineData("S", DateIndicator.S)]
        [InlineData("N", DateIndicator.N)]
        [InlineData("P", DateIndicator.P)]
        public void returns_expected_result_from_argument(string value, DateIndicator expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void returns_none_when_argument_is_unknown()
        {
            var parser = BuildParser();

            var result = parser.ParseProperty("ZZZ");

            Assert.Equal(DateIndicator.None, result);
        }
    }
}
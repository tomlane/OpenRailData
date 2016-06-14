using System;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.ScheduleParsing.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    
    public class TLocationActivityParser
    {
        private LocationActivityParser BuildParser()
        {
            return new LocationActivityParser();
        }

        [Fact]
        public void throws_if_argument_string_is_null()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Theory]
        [InlineData("A ", LocationActivity.A)]
        [InlineData("BL", LocationActivity.BL)]
        [InlineData("-D", LocationActivity.MinusD)]
        public void returns_expected_result(string value, LocationActivity expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);

            Assert.True(result.HasFlag(expectedResult));
        }
    }
}
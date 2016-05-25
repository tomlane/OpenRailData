using System;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    public class TLocationTypeParser
    {
        private LocationTypeParser BuildParser()
        {
            return new LocationTypeParser();
        }

        [Fact]
        public void returns_correct_property_key()
        {
            var parser = BuildParser();

            Assert.Equal("LocationType", parser.PropertyKey);
        }

        [Fact]
        public void throws_when_argument_is_null_or_invalid()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(string.Empty));
            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(" \t"));
        }

        [Theory]
        [InlineData("LO", LocationType.LO)]
        [InlineData("LI", LocationType.LI)]
        [InlineData("LT", LocationType.LT)]
        public void returns_expected_result_when_argument_is_valid(string value, LocationType expectedResult)
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
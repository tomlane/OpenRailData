using System;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    
    public class TExtractUpdateTypeParser
    {
        private ExtractUpdateTypeParser BuildParser()
        {
            return new ExtractUpdateTypeParser();
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
        [InlineData("F", ExtractUpdateType.F)]
        [InlineData("U", ExtractUpdateType.U)]
        public void returns_expected_result_when_argument_is_valid(string value, ExtractUpdateType expectedResult)
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
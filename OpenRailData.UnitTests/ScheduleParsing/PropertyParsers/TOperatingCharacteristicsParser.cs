using OpenRailData.Schedule.Entities.Enums;
using OpenRailData.Schedule.ScheduleParsing.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    
    public class TOperatingCharacteristicsParser
    {
        private OperatingCharacteristicsParser BuildParser()
        {
            return new OperatingCharacteristicsParser();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void returns_zero_when_argument_is_empty_string_or_null(string argument)
        {
            var parser = BuildParser();

            Assert.Equal((OperatingCharacteristics)0, parser.ParseProperty(argument));
        }

        [Theory]
        [InlineData("B", OperatingCharacteristics.B)]
        [InlineData("G", OperatingCharacteristics.G)]
        [InlineData("S", OperatingCharacteristics.S)]
        public void returns_expected_result(string value, OperatingCharacteristics expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);

            Assert.True(result.HasFlag(expectedResult));
        }
    }
}

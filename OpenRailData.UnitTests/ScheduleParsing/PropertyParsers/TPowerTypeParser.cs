using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.ScheduleParsing.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    
    public class TPowerTypeParser
    {
        private PowerTypeParser BuildParser()
        {
            return new PowerTypeParser();
        }

        [Theory]
        [InlineData("D", PowerType.D)]
        [InlineData("DMU", PowerType.DMU)]
        [InlineData("HST", PowerType.HST)]
        [InlineData(null, PowerType.None)]
        public void returns_expected_result_when_argument_is_valid(string value, PowerType expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void returns_none_when_argument_is_unknown()
        {
            var parser = BuildParser();

            var result = parser.ParseProperty("XYZ");

            Assert.Equal(PowerType.None, result);
        }
    }
}
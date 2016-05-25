using System;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    
    public class TOperatingCharacteristicsParser
    {
        private OperatingCharacteristicsParser BuildParser()
        {
            return new OperatingCharacteristicsParser();
        }

        [Fact]
        public void throws_when_argument_is_empty_string()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
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

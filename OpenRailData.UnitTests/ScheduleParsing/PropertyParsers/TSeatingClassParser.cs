using System;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    
    public class TSeatingClassParser
    {
        private SeatingClassParser BuildParser()
        {
            return new SeatingClassParser();
        }

        [Fact]
        public void returns_B_when_argument_is_null()
        {
            var parser = BuildParser();

            Assert.Equal(SeatingClass.B, parser.ParseProperty(null));
        }

        [Fact]
        public void returns_expected_result_when_argument_string_is_empty()
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(string.Empty);

            Assert.Equal(SeatingClass.B, result);
        }

        [Theory]
        [InlineData("S", SeatingClass.S)]
        [InlineData("B", SeatingClass.B)]
        public void returns_expected_result_when_argument_is_not_empty(string value, SeatingClass expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);

            Assert.Equal(expectedResult, result);
        }
    }
}
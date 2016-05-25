using System;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    public class TCateringCodeParser
    {
        private CateringCodeParser BuildParser()
        {
            return new CateringCodeParser();
        }

        [Fact]
        public void throws_if_argument_string_is_null()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Theory]
        [InlineData("C", CateringCode.C)]
        [InlineData("F", CateringCode.F)]
        [InlineData("H", CateringCode.H)]
        [InlineData("M", CateringCode.M)]
        [InlineData("P", CateringCode.P)]
        [InlineData("R", CateringCode.R)]
        [InlineData("T", CateringCode.T)]
        public void returns_expected_result(string value, CateringCode expectedResult)
        {
            var parser = BuildParser();
            
            var result = parser.ParseProperty(value);

            Assert.True(result.HasFlag(expectedResult));
        }
    }
}
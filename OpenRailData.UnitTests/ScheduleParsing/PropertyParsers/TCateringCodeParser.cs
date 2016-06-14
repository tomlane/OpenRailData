using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.ScheduleParsing.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    public class TCateringCodeParser
    {
        private CateringCodeParser BuildParser()
        {
            return new CateringCodeParser();
        }

        [Theory]
        [InlineData("C", CateringCode.C)]
        [InlineData("F", CateringCode.F)]
        [InlineData("H", CateringCode.H)]
        [InlineData("M", CateringCode.M)]
        [InlineData("P", CateringCode.P)]
        [InlineData("R", CateringCode.R)]
        [InlineData("T", CateringCode.T)]
        [InlineData(null, CateringCode.None)]
        public void returns_expected_result(string value, CateringCode expectedResult)
        {
            var parser = BuildParser();
            
            var result = parser.ParseProperty(value);

            Assert.True(result.HasFlag(expectedResult));
        }
    }
}
using System;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    
    public class TTrainSleeperDetailsParser
    {
        
        class ParseTrainSleeperDetails
        {
            [Fact]
            public void throws_when_argument_is_null_or_empty()
            {
                var parser = new SleeperDetailsParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            }

            [Fact]
            [InlineData("B", SleeperDetails.B)]
            [InlineData("F", SleeperDetails.F)]
            [InlineData("S", SleeperDetails.S)]
            public void returns_expected_result_from_argument(string value, SleeperDetails expectedResult)
            {
                var parser = new SleeperDetailsParser();

                var result = parser.ParseProperty(value);

                Assert.Equal(expectedResult, result);
            }

            [Fact]
            public void returns_not_available_when_argument_is_unknown()
            {
                var parser = new SleeperDetailsParser();

                var result = parser.ParseProperty("zzz");

                Assert.Equal(SleeperDetails.NotAvailable, result);
            }
        }
    }
}
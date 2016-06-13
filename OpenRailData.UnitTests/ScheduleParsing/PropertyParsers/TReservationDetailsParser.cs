using System;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    
    public class TReservationDetailsParser
    {
        private ReservationDetailsParser BuildParser()
        {
            return new ReservationDetailsParser();
        }

        [Theory]
        [InlineData("A", ReservationDetails.A)]
        [InlineData("E", ReservationDetails.E)]
        [InlineData("R", ReservationDetails.R)]
        [InlineData("S", ReservationDetails.S)]
        [InlineData(null, ReservationDetails.None)]
        public void returns_expected_result_from_argument(string value, ReservationDetails expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void returns_none_when_argument_is_unknown()
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(" ");

            Assert.Equal(ReservationDetails.None, result);
        }
    }
}
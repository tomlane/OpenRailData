﻿using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.ScheduleParsing.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    public class TBankHolidayRunningParser
    {
        private BankHolidayRunningParser BuildParser()
        {
            return new BankHolidayRunningParser();
        }

        [Fact]
        public void returns_not_running_when_argument_is_null()
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(null);

            Assert.Equal(BankHolidayRunning.X, result);
        }

        [Theory]
        [InlineData("X", BankHolidayRunning.X)]
        [InlineData("G", BankHolidayRunning.G)]
        public void returns_expected_non_running_value(string value, BankHolidayRunning expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void returns_expected_running_value()
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(string.Empty);
            Assert.Equal(BankHolidayRunning.R, result);
        }
    }
}
﻿using System;
using NUnit.Framework;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TBankHolidayRunningParser
    {
        private BankHolidayRunningParser BuildParser()
        {
            return new BankHolidayRunningParser();
        }

        [Test]
        public void throws_when_argument_is_null()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Test]
        [TestCase("X", BankHolidayRunning.X)]
        [TestCase("G", BankHolidayRunning.G)]
        public void returns_expected_non_running_value(string value, BankHolidayRunning expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void returns_expected_running_value()
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(string.Empty);
            Assert.AreEqual(BankHolidayRunning.R, result);
        }
    }
}
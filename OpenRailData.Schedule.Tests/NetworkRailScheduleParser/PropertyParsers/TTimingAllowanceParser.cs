﻿using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TTimingAllowanceParser
    {
        private TimingAllowanceParser BuildParser()
        {
            return new TimingAllowanceParser();
        }

        [Test]
        public void returns_null_when_argument_is_null_or_empty()
        {
            var parser = BuildParser();

            Assert.IsNull(parser.ParseTime(null));
            Assert.IsNull(parser.ParseTime(string.Empty));
            Assert.IsNull(parser.ParseTime(" \t "));
        }

        [Test]
        public void returns_null_when_argument_is_four_zeros()
        {
            var parser = BuildParser();

            Assert.IsNull(parser.ParseTime("0000"));
        }

        [Test]
        public void returns_expected_result_for_half_time()
        {
            var parser = BuildParser();

            var result = parser.ParseTime("H");
            Assert.AreEqual(TimeSpan.FromSeconds(30), result);

            result = parser.ParseTime("2H");
            Assert.AreEqual(TimeSpan.FromSeconds(150), result);
        }

        [Test]
        public void returns_expected_result_with_white_space()
        {
            var parser = BuildParser();

            var result = parser.ParseTime("1020 ");
            Assert.AreEqual(new TimeSpan(0, 10, 20, 0), result);
        }

        [Test]
        public void returns_expected_result_for_whole_minutes()
        {
            var parser = BuildParser();

            var result = parser.ParseTime("1");
            Assert.AreEqual(TimeSpan.FromMinutes(1), result);

            result = parser.ParseTime("15");
            Assert.AreEqual(TimeSpan.FromMinutes(15), result);
        }

        [Test]
        public void returns_expected_result_for_hours_and_minutes()
        {
            var parser = BuildParser();

            var result = parser.ParseTime("1028");
            Assert.AreEqual(new TimeSpan(0, 10, 28, 0), result);
        }

        [Test]
        public void returns_null_when_argument_is_invalid()
        {
            var parser = BuildParser();

            var result = parser.ParseTime("Y");
            Assert.IsNull(result);

            result = parser.ParseTime("XYZ|");
            Assert.IsNull(result);
        }
    }
}
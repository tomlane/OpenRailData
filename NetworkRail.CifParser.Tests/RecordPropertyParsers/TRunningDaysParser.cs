using System;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordPropertyParsers
{
    [TestFixture]
    public class TRunningDaysParser
    {
        [TestFixture]
        class ParseRunningDays
        {
            [Test]
            public void throws_when_argument_is_null_or_whitespace()
            {
                var parser = new RunningDaysParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseRunningDays(null));
            }

            [Test]
            public void throws_when_argument_is_incorrect_length()
            {
                var parser = new RunningDaysParser();
                
                Assert.Throws<ArgumentException>(() => parser.ParseRunningDays("12345678"));
                Assert.Throws<ArgumentException>(() => parser.ParseRunningDays("123456"));
            }

            [Test]
            public void returns_expected_result_running_all_days()
            {
                var parser = new RunningDaysParser();

                var result = parser.ParseRunningDays("1111111");

                var expectedResult = Days.Monday | Days.Tuesday | Days.Wednesday | Days.Thursday | Days.Friday |
                                     Days.Saturday | Days.Sunday;

                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void returns_expected_result_weekdays_only()
            {
                var parser = new RunningDaysParser();

                var result = parser.ParseRunningDays("1111100");

                var expectedResult = Days.Monday | Days.Tuesday | Days.Wednesday | Days.Thursday | Days.Friday;

                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void returns_expected_result_weekends_only()
            {
                var parser = new RunningDaysParser();

                var result = parser.ParseRunningDays("0000011");

                var expectedResult = Days.Saturday | Days.Sunday;

                Assert.AreEqual(expectedResult, result);
            }
            
        }
    }
}
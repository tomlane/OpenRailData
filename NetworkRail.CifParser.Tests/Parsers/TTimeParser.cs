using System;
using NetworkRail.CifParser.Parsers;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.Parsers
{
    [TestFixture]
    public class TTimeParser
    {
        [TestFixture]
        class ParseTime
        {
            [Test]
            public void returns_null_when_argument_is_null_or_empty()
            {
                var parser = new TimeParser();

                var result = parser.ParseTime(null);
                Assert.IsNull(result);

                result = parser.ParseTime(string.Empty);
                Assert.IsNull(result);

                result = parser.ParseTime(" \t ");
                Assert.IsNull(result);
            }

            [Test]
            public void returns_expected_result_for_half_time()
            {
                var parser = new TimeParser();

                var result = parser.ParseTime("H");
                Assert.AreEqual(TimeSpan.FromSeconds(30), result);

                result = parser.ParseTime("2H");
                Assert.AreEqual(TimeSpan.FromSeconds(150), result);
            }

            [Test]
            public void returns_expected_result_for_whole_minutes()
            {
                var parser = new TimeParser();

                var result = parser.ParseTime("1");
                Assert.AreEqual(TimeSpan.FromMinutes(1), result);

                result = parser.ParseTime("15");
                Assert.AreEqual(TimeSpan.FromMinutes(15), result);
            }

            [Test]
            public void returns_expected_result_for_hours_and_minutes()
            {
                var parser = new TimeParser();

                var result = parser.ParseTime("1028");
                Assert.AreEqual(TimeSpan.FromHours(10).Add(TimeSpan.FromMinutes(28)), result);
            }

            [Test]
            public void returns_null_when_argument_is_invalid()
            {
                var parser = new TimeParser();

                var result = parser.ParseTime("Y");
                Assert.IsNull(result);

                result = parser.ParseTime("XYZ|");
                Assert.IsNull(result);
            }
        }
    }
}
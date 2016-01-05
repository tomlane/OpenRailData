using System;
using NetworkRail.CifParser.Parsers;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.Parsers
{
    [TestFixture]
    public class TTimeParser
    {
        [TestFixture]
        class ParseNullableTime
        {
            [Test]
            public void returns_null_when_argument_is_null_or_empty()
            {
                var parser = new TimeParser();

                var result = parser.ParseNullableTime(null);
                Assert.IsNull(result);

                result = parser.ParseNullableTime(string.Empty);
                Assert.IsNull(result);

                result = parser.ParseNullableTime(" \t ");
                Assert.IsNull(result);
            }

            [Test]
            public void returns_expected_result_for_half_time()
            {
                var parser = new TimeParser();

                var result = parser.ParseNullableTime("H");
                Assert.AreEqual(TimeSpan.FromSeconds(30), result);

                result = parser.ParseNullableTime("2H");
                Assert.AreEqual(TimeSpan.FromSeconds(150), result);
            }

            [Test]
            public void returns_expected_result_for_whole_minutes()
            {
                var parser = new TimeParser();

                var result = parser.ParseNullableTime("1");
                Assert.AreEqual(TimeSpan.FromMinutes(1), result);

                result = parser.ParseNullableTime("15");
                Assert.AreEqual(TimeSpan.FromMinutes(15), result);
            }

            [Test]
            public void returns_null_when_argument_is_invalid()
            {
                var parser = new TimeParser();

                var result = parser.ParseNullableTime("Y");
                Assert.IsNull(result);

                result = parser.ParseNullableTime("XYZ|");
                Assert.IsNull(result);
            }
        }
    }
}
using System;
using NetworkRail.CifParser.RecordPropertyParsers;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordPropertyParsers
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
                var parser = new TimingAllowanceParser();

                var result = parser.ParseTime(null);
                Assert.IsNull(result);

                result = parser.ParseTime(string.Empty);
                Assert.IsNull(result);

                result = parser.ParseTime(" \t ");
                Assert.IsNull(result);
            }

            [Test]
            public void returns_null_when_argument_is_four_zeros()
            {
                var parser = new TimingAllowanceParser();

                Assert.IsNull(parser.ParseTime("0000"));
            }

            [Test]
            public void returns_expected_result_for_half_time()
            {
                var parser = new TimingAllowanceParser();

                var result = parser.ParseTime("H");
                Assert.AreEqual(TimeSpan.FromSeconds(30), result);

                result = parser.ParseTime("2H");
                Assert.AreEqual(TimeSpan.FromSeconds(150), result);
            }

            [Test]
            public void returns_expected_result_with_white_space()
            {
                var parser = new TimingAllowanceParser();

                var result = parser.ParseTime("1020 ");
                Assert.AreEqual(new TimeSpan(0, 10, 20, 0), result);
            }

            [Test]
            public void returns_expected_result_for_whole_minutes()
            {
                var parser = new TimingAllowanceParser();

                var result = parser.ParseTime("1");
                Assert.AreEqual(TimeSpan.FromMinutes(1), result);

                result = parser.ParseTime("15");
                Assert.AreEqual(TimeSpan.FromMinutes(15), result);
            }

            [Test]
            public void returns_expected_result_for_hours_and_minutes()
            {
                var parser = new TimingAllowanceParser();

                var result = parser.ParseTime("1028");
                Assert.AreEqual(new TimeSpan(0, 10, 28, 0), result);
            }

            [Test]
            public void returns_null_when_argument_is_invalid()
            {
                var parser = new TimingAllowanceParser();

                var result = parser.ParseTime("Y");
                Assert.IsNull(result);

                result = parser.ParseTime("XYZ|");
                Assert.IsNull(result);
            }
        }
    }
}
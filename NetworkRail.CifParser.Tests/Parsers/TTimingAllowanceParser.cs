using System;
using NetworkRail.CifParser.Parsers;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.Parsers
{
    [TestFixture]
    public class TTimingAllowanceParser
    {
        [TestFixture]
        class ParseTimingAllowance
        {
            [Test]
            public void returns_null_when_argument_is_null_or_empty()
            {
                var parser = new TimingAllowanceParser();

                var result = parser.ParseTimingAllowance(null);
                Assert.IsNull(result);

                result = parser.ParseTimingAllowance(string.Empty);
                Assert.IsNull(result);

                result = parser.ParseTimingAllowance(" \t ");
                Assert.IsNull(result);
            }

            [Test]
            public void returns_expected_result_for_half_time()
            {
                var parser = new TimingAllowanceParser();

                var result = parser.ParseTimingAllowance("H");
                Assert.AreEqual(TimeSpan.FromSeconds(30), result);

                result = parser.ParseTimingAllowance("2H");
                Assert.AreEqual(TimeSpan.FromSeconds(150), result);
            }

            [Test]
            public void returns_expected_result_for_whole_minutes()
            {
                var parser = new TimingAllowanceParser();

                var result = parser.ParseTimingAllowance("1");
                Assert.AreEqual(TimeSpan.FromMinutes(1), result);

                result = parser.ParseTimingAllowance("15");
                Assert.AreEqual(TimeSpan.FromMinutes(15), result);
            }

            [Test]
            public void returns_null_when_argument_is_invalid()
            {
                var parser = new TimingAllowanceParser();

                var result = parser.ParseTimingAllowance("Y");
                Assert.IsNull(result);

                result = parser.ParseTimingAllowance("XYZ|");
                Assert.IsNull(result);
            }
        }
    }
}
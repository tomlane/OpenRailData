using System;
using NUnit.Framework;
using OpenRailData.Schedule.PropertyParsers.NetworkRail;
using OpenRailData.Schedule.Records.NetworkRail.Enums;

namespace OpenRailData.Schedule.Tests.PropertyParsers.NetworkRail
{
    [TestFixture]
    public class TDateIndicatorParser
    {
        [TestFixture]
        class ParseDateIndicator
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var parser = new DateIndicatorParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            }

            [Test]
            public void returns_expected_result_from_argument()
            {
                var parser = new DateIndicatorParser();

                var result = parser.ParseProperty("S");
                Assert.AreEqual(DateIndicator.S, result);

                result = parser.ParseProperty("N");
                Assert.AreEqual(DateIndicator.N, result);

                result = parser.ParseProperty("P");
                Assert.AreEqual(DateIndicator.P, result);
            }

            [Test]
            public void returns_none_when_argument_is_unknown()
            {
                var parser = new DateIndicatorParser();

                var result = parser.ParseProperty("ZZZ");

                Assert.AreEqual(DateIndicator.None, result);
            }
        }
    }
}
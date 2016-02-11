using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
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
            [TestCase("S", DateIndicator.S)]
            [TestCase("N", DateIndicator.N)]
            [TestCase("P", DateIndicator.P)]
            public void returns_expected_result_from_argument(string value, DateIndicator expectedResult)
            {
                var parser = new DateIndicatorParser();

                var result = parser.ParseProperty(value);

                Assert.AreEqual(expectedResult, result);
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
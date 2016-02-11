using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TStpIndicatorParser
    {
        [TestFixture]
        class ParseStpIndicator
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var parser = new StpIndicatorParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(string.Empty));
                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(" \t"));
            }

            [Test]
            [TestCase("C", StpIndicator.C)]
            [TestCase("N", StpIndicator.N)]
            [TestCase("O", StpIndicator.O)]
            [TestCase("P", StpIndicator.P)]
            public void returns_expected_result_from_argument(string value, StpIndicator expectedResult)
            {
                var parser = new StpIndicatorParser();

                var result = parser.ParseProperty(value);

                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void throws_when_argument_is_unknown()
            {
                var parser = new StpIndicatorParser();

                Assert.Throws<ArgumentException>(() => parser.ParseProperty("Z"));
            }
        }
    }
}
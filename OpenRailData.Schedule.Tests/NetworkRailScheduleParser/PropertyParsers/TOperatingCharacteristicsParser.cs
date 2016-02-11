using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TOperatingCharacteristicsParser
    {
        [TestFixture]
        class ParseOperatingCharacteristics
        {
            [Test]
            public void throws_when_argument_is_empty_string()
            {
                var parser = new OperatingCharacteristicsParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            }

            [Test]
            [TestCase("B", OperatingCharacteristics.B)]
            [TestCase("G", OperatingCharacteristics.G)]
            [TestCase("S", OperatingCharacteristics.S)]
            public void returns_expected_result(string value, OperatingCharacteristics expectedResult)
            {
                var parser = new OperatingCharacteristicsParser();

                var result = parser.ParseProperty(value);

                Assert.IsTrue(result.HasFlag(expectedResult));
            }
        }
    }
}
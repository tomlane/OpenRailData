using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TLocationActivityParser
    {
        private LocationActivityParser BuildParser()
        {
            return new LocationActivityParser();
        }

        [Test]
        public void throws_if_argument_string_is_null()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Test]
        [TestCase("A ", LocationActivity.A)]
        [TestCase("BL", LocationActivity.BL)]
        [TestCase("-D", LocationActivity.MinusD)]
        public void returns_expected_result(string value, LocationActivity expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);

            Assert.IsTrue(result.HasFlag(expectedResult));
        }
    }
}
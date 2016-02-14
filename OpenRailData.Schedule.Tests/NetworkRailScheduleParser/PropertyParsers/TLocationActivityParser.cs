using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;

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
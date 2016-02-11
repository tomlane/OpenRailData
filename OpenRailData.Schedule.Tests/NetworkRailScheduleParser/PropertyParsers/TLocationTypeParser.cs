using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    public class TLocationTypeParser
    {
        [Test]
        public void throws_when_argument_is_null_or_invalid()
        {
            var parser = new LocationTypeParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(string.Empty));
            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(" \t"));
        }

        [Test]
        [TestCase("LO", LocationType.LO)]
        [TestCase("LI", LocationType.LI)]
        [TestCase("LT", LocationType.LT)]
        public void returns_expected_result_when_argument_is_valid(string value, LocationType expectedResult)
        {
            var parser = new LocationTypeParser();

            var result = parser.ParseProperty(value);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void throws_when_argument_is_unknown()
        {
            var parser = new LocationTypeParser();

            Assert.Throws<ArgumentException>(() => parser.ParseProperty("Z"));
        }
    }
}
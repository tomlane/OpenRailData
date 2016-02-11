using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TPowerTypeParser
    {
        [Test]
        public void throws_when_argument_is_null_or_invalid()
        {
            var parser = new PowerTypeParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Test]
        [TestCase("D", PowerType.D)]
        [TestCase("DMU", PowerType.DMU)]
        [TestCase("HST", PowerType.HST)]
        public void returns_expected_result_when_argument_is_valid(string value, PowerType expectedResult)
        {
            var parser = new PowerTypeParser();

            var result = parser.ParseProperty(value);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void returns_none_when_argument_is_unknown()
        {
            var parser = new PowerTypeParser();

            var result = parser.ParseProperty("XYZ");
            Assert.AreEqual(PowerType.None, result);
        }
    }
}
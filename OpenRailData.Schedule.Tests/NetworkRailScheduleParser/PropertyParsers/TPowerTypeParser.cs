using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TPowerTypeParser
    {
        private PowerTypeParser BuildParser()
        {
            return new PowerTypeParser();
        }

        [Test]
        public void throws_when_argument_is_null_or_invalid()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Test]
        [TestCase("D", PowerType.D)]
        [TestCase("DMU", PowerType.DMU)]
        [TestCase("HST", PowerType.HST)]
        public void returns_expected_result_when_argument_is_valid(string value, PowerType expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void returns_none_when_argument_is_unknown()
        {
            var parser = BuildParser();

            var result = parser.ParseProperty("XYZ");

            Assert.AreEqual(PowerType.None, result);
        }
    }
}
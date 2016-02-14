using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TServiceBrandingParser
    {
        private ServiceBrandingParser BuildParser()
        {
            return new ServiceBrandingParser();
        }

        [Test]
        public void throws_when_argument_is_invalid()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Test]
        [TestCase("E", ServiceBranding.E)]
        public void returns_expected_result_from_argument(string value, ServiceBranding expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void returns_none_when_argument_is_unknown()
        {
            var parser = BuildParser();

            var result = parser.ParseProperty("ZZZ");

            Assert.AreEqual(ServiceBranding.None, result);
        }
    }
}
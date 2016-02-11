using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TServiceBrandingParser
    {
        [Test]
        public void throws_when_argument_is_invalid()
        {
            var parser = new ServiceBrandingParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Test]
        [TestCase("E", ServiceBranding.E)]
        public void returns_expected_result_from_argument(string value, ServiceBranding expectedResult)
        {
            var parser = new ServiceBrandingParser();

            var result = parser.ParseProperty(value);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void returns_none_when_argument_is_unknown()
        {
            var parser = new ServiceBrandingParser();

            var result = parser.ParseProperty("ZZZ");

            Assert.AreEqual(ServiceBranding.None, result);
        }
    }
}
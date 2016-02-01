using System;
using NUnit.Framework;
using OpenRailData.Schedule.PropertyParsers.NetworkRail;
using OpenRailData.Schedule.Records.NetworkRail.Enums;

namespace OpenRailData.Schedule.Tests.PropertyParsers.NetworkRail
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
        public void returns_expected_result_from_argument()
        {
            var parser = new ServiceBrandingParser();

            var result = parser.ParseProperty("E");
            Assert.AreEqual(ServiceBranding.E, result);
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
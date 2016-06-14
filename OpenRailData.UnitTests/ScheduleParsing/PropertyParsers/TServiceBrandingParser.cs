using System;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.ScheduleParsing.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    
    public class TServiceBrandingParser
    {
        private ServiceBrandingParser BuildParser()
        {
            return new ServiceBrandingParser();
        }

        [Fact]
        public void throws_when_argument_is_invalid()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Theory]
        [InlineData("E", ServiceBranding.E)]
        public void returns_expected_result_from_argument(string value, ServiceBranding expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void returns_none_when_argument_is_unknown()
        {
            var parser = BuildParser();

            var result = parser.ParseProperty("ZZZ");

            Assert.Equal(ServiceBranding.None, result);
        }
    }
}
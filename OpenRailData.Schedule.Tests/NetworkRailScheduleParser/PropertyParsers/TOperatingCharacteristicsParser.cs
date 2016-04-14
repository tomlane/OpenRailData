using System;
using NUnit.Framework;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;
using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TOperatingCharacteristicsParser
    {
        private OperatingCharacteristicsParser BuildParser()
        {
            return new OperatingCharacteristicsParser();
        }

        [Test]
        public void throws_when_argument_is_empty_string()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Test]
        [TestCase("B", OperatingCharacteristics.B)]
        [TestCase("G", OperatingCharacteristics.G)]
        [TestCase("S", OperatingCharacteristics.S)]
        public void returns_expected_result(string value, OperatingCharacteristics expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);

            Assert.IsTrue(result.HasFlag(expectedResult));
        }
    }
}

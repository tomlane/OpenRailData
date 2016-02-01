using System;
using NUnit.Framework;
using OpenRailData.Schedule.PropertyParsers.NetworkRail;
using OpenRailData.Schedule.Records.NetworkRail.Enums;

namespace OpenRailData.Schedule.Tests.PropertyParsers.NetworkRail
{
    [TestFixture]
    public class TOperatingCharacteristicsParser
    {
        [TestFixture]
        class ParseOperatingCharacteristics
        {
            [Test]
            public void throws_when_argument_is_empty_string()
            {
                var parser = new OperatingCharacteristicsParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            }

            [Test]
            public void returns_expected_result()
            {
                var parser = new OperatingCharacteristicsParser();

                string characteristics = "BCDEGMPQRSYZ";

                var result = parser.ParseProperty(characteristics);

                Assert.IsTrue(result.HasFlag(OperatingCharacteristics.B));
                Assert.IsTrue(result.HasFlag(OperatingCharacteristics.C));
                Assert.IsTrue(result.HasFlag(OperatingCharacteristics.D));
                Assert.IsTrue(result.HasFlag(OperatingCharacteristics.E));
                Assert.IsTrue(result.HasFlag(OperatingCharacteristics.G));
                Assert.IsTrue(result.HasFlag(OperatingCharacteristics.M));
                Assert.IsTrue(result.HasFlag(OperatingCharacteristics.P));
                Assert.IsTrue(result.HasFlag(OperatingCharacteristics.Q));
                Assert.IsTrue(result.HasFlag(OperatingCharacteristics.R));
                Assert.IsTrue(result.HasFlag(OperatingCharacteristics.S));
                Assert.IsTrue(result.HasFlag(OperatingCharacteristics.Y));
                Assert.IsTrue(result.HasFlag(OperatingCharacteristics.Z));
            }
        }
    }
}
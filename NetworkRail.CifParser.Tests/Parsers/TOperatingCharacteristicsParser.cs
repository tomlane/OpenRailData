using System;
using NetworkRail.CifParser.Parsers;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.Parsers
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

                Assert.Throws<ArgumentNullException>(() => parser.ParseOperatingCharacteristics(null));
            }

            [Test]
            public void returns_expected_result()
            {
                var parser = new OperatingCharacteristicsParser();

                string characteristics = "BCDEGMPQRSYZ";

                var result = parser.ParseOperatingCharacteristics(characteristics);

                Assert.IsTrue(result.B);
                Assert.IsTrue(result.C);
                Assert.IsTrue(result.D);
                Assert.IsTrue(result.E);
                Assert.IsTrue(result.G);
                Assert.IsTrue(result.M);
                Assert.IsTrue(result.P);
                Assert.IsTrue(result.Q);
                Assert.IsTrue(result.R);
                Assert.IsTrue(result.S);
                Assert.IsTrue(result.Y);
                Assert.IsTrue(result.Z);
            }
        }
    }
}
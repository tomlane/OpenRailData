using System;
using NetworkRail.CifParser.Parsers;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests
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
        }
    }
}
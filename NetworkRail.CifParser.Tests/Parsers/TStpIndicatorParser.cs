using System;
using NetworkRail.CifParser.Parsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.Parsers
{
    [TestFixture]
    public class TStpIndicatorParser
    {
        [TestFixture]
        class ParseStpIndicator
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var parser = new StpIndicatorParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseStpIndicator(null));
                Assert.Throws<ArgumentNullException>(() => parser.ParseStpIndicator(string.Empty));
                Assert.Throws<ArgumentNullException>(() => parser.ParseStpIndicator(" \t"));
            }

            [Test]
            public void returns_expected_result_from_argument()
            {
                var parser = new StpIndicatorParser();

                var result = parser.ParseStpIndicator("C");
                Assert.AreEqual(StpIndicator.Cancellation, result);

                result = parser.ParseStpIndicator("N");
                Assert.AreEqual(StpIndicator.New, result);

                result = parser.ParseStpIndicator("O");
                Assert.AreEqual(StpIndicator.Overlay, result);

                result = parser.ParseStpIndicator("P");
                Assert.AreEqual(StpIndicator.Permanent, result);
            }

            [Test]
            public void throws_when_argument_is_unknown()
            {
                var parser = new StpIndicatorParser();

                Assert.Throws<ArgumentException>(() => parser.ParseStpIndicator("Z"));
            }
        }
    }
}
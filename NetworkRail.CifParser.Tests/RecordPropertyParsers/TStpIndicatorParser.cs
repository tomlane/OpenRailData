using System;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordPropertyParsers
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

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(string.Empty));
                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(" \t"));
            }

            [Test]
            public void returns_expected_result_from_argument()
            {
                var parser = new StpIndicatorParser();

                var result = parser.ParseProperty("C");
                Assert.AreEqual(StpIndicator.C, result);

                result = parser.ParseProperty("N");
                Assert.AreEqual(StpIndicator.N, result);

                result = parser.ParseProperty("O");
                Assert.AreEqual(StpIndicator.O, result);

                result = parser.ParseProperty("P");
                Assert.AreEqual(StpIndicator.P, result);
            }

            [Test]
            public void throws_when_argument_is_unknown()
            {
                var parser = new StpIndicatorParser();

                Assert.Throws<ArgumentException>(() => parser.ParseProperty("Z"));
            }
        }
    }
}
using System;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordPropertyParsers
{
    [TestFixture]
    public class TExtractUpdateTypeParser
    {
        [TestFixture]
        class ParseExtractUpdateType
        {
            [Test]
            public void throws_when_argument_is_null_or_invalid()
            {
                var parser = new ExtractUpdateTypeParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseExtractUpdateType(null));
                Assert.Throws<ArgumentNullException>(() => parser.ParseExtractUpdateType(string.Empty));
                Assert.Throws<ArgumentNullException>(() => parser.ParseExtractUpdateType(" \t"));
            }

            [Test]
            public void returns_expected_result_when_argument_is_valid()
            {
                var parser = new ExtractUpdateTypeParser();

                var result = parser.ParseExtractUpdateType("F");
                Assert.AreEqual(ExtractUpdateType.FullExtract, result);

                result = parser.ParseExtractUpdateType("U");
                Assert.AreEqual(ExtractUpdateType.UpdateExtract, result);
            }

            [Test]
            public void throws_when_argument_is_unknown()
            {
                var parser = new ExtractUpdateTypeParser();

                Assert.Throws<ArgumentException>(() => parser.ParseExtractUpdateType("Z"));
            }
        }
    }
}
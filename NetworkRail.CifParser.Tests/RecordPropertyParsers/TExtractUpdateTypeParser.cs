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

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(string.Empty));
                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(" \t"));
            }

            [Test]
            public void returns_expected_result_when_argument_is_valid()
            {
                var parser = new ExtractUpdateTypeParser();

                var result = parser.ParseProperty("F");
                Assert.AreEqual(ExtractUpdateType.F, result);

                result = parser.ParseProperty("U");
                Assert.AreEqual(ExtractUpdateType.U, result);
            }

            [Test]
            public void throws_when_argument_is_unknown()
            {
                var parser = new ExtractUpdateTypeParser();

                Assert.Throws<ArgumentException>(() => parser.ParseProperty("Z"));
            }
        }
    }
}
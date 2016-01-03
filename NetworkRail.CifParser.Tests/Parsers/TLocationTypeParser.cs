using System;
using NetworkRail.CifParser.Parsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.Parsers
{
    [TestFixture]
    public class TLocationTypeParser
    {
        [Test]
        public void throws_when_string_is_null_or_empty()
        {
            var parser = new LocationTypeParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseLocationType(null));
            Assert.Throws<ArgumentNullException>(() => parser.ParseLocationType(string.Empty));
            Assert.Throws<ArgumentNullException>(() => parser.ParseLocationType(" \t"));
        }

        [Test]
        public void returns_expected_result_from_argument()
        {
            var parser = new LocationTypeParser();

            var result = parser.ParseLocationType("LO");
            Assert.AreEqual(LocationType.Originating, result);

            result = parser.ParseLocationType("LI");
            Assert.AreEqual(LocationType.Intermediate, result);

            result = parser.ParseLocationType("LT");
            Assert.AreEqual(LocationType.Terminating, result);
        }

        [Test]
        public void throws_when_argument_is_unknown()
        {
            var parser = new LocationTypeParser();

            Assert.Throws<ArgumentException>(() => parser.ParseLocationType("Z"));
        }
    }
}
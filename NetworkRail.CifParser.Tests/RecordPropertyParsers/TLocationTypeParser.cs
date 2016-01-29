using System;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordPropertyParsers
{
    public class TLocationTypeParser
    {
        [Test]
        public void throws_when_argument_is_null_or_invalid()
        {
            var parser = new LocationTypeParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(string.Empty));
            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(" \t"));
        }

        [Test]
        public void returns_expected_result_when_argument_is_valid()
        {
            var parser = new LocationTypeParser();

            var result = parser.ParseProperty("LO");
            Assert.AreEqual(LocationType.LO, result);

            result = parser.ParseProperty("LI");
            Assert.AreEqual(LocationType.LI, result);

            result = parser.ParseProperty("LT");
            Assert.AreEqual(LocationType.LT, result);
        }

        [Test]
        public void throws_when_argument_is_unknown()
        {
            var parser = new LocationTypeParser();

            Assert.Throws<ArgumentException>(() => parser.ParseProperty("Z"));
        }
    }
}
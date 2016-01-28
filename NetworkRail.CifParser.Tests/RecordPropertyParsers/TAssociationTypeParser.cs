using System;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordPropertyParsers
{
    [TestFixture]
    public class TAssociationTypeParser
    {
        [Test]
        public void throws_when_argument_is_invalid()
        {
            var parser = new AssociationTypeParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Test]
        public void returns_expected_result_when_valid()
        {
            var parser = new AssociationTypeParser();

            var result = parser.ParseProperty("P");
            Assert.AreEqual(AssociationType.P, result);

            result = parser.ParseProperty("O");
            Assert.AreEqual(AssociationType.O, result);
        }

        [Test]
        public void returns_none_when_argument_is_unknown()
        {
            var parser = new AssociationTypeParser();

            var result = parser.ParseProperty("XYZ");
            Assert.AreEqual(AssociationType.None, result);

        }
    }
}
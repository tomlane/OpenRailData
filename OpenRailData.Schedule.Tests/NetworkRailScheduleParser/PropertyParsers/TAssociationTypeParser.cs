using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
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
        [TestCase("P", AssociationType.P)]
        [TestCase("O", AssociationType.O)]
        public void returns_expected_result_when_valid(string value, AssociationType expectedResult)
        {
            var parser = new AssociationTypeParser();

            var result = parser.ParseProperty(value);
            Assert.AreEqual(expectedResult, result);
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
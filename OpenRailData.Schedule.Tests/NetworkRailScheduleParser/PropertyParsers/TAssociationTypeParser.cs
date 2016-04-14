using System;
using NUnit.Framework;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;
using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TAssociationTypeParser
    {
        private AssociationTypeParser BuildParser()
        {
            return new AssociationTypeParser();
        }

        [Test]
        public void throws_when_argument_is_invalid()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Test]
        [TestCase("P", AssociationType.P)]
        [TestCase("O", AssociationType.O)]
        public void returns_expected_result_when_valid(string value, AssociationType expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void returns_none_when_argument_is_unknown()
        {
            var parser = BuildParser();

            var result = parser.ParseProperty("XYZ");
            Assert.AreEqual(AssociationType.None, result);

        }
    }
}
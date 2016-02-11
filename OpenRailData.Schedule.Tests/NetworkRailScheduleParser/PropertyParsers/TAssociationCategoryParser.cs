using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TAssociationCategoryParser
    {
        [TestFixture]
        class ParseAssociationCategory
        {
            [Test]
            public void throws_when_argument_is_invalid()
            {
                var parser = new AssociationCategoryParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            }

            [Test]
            [TestCase("JJ", AssociationCategory.JJ)]
            [TestCase("VV", AssociationCategory.VV)]
            [TestCase("NP", AssociationCategory.NP)]
            public void returns_expected_result_when_valid(string value, AssociationCategory expectedResult)
            {
                var parser = new AssociationCategoryParser();

                var result = parser.ParseProperty(value);
                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void returns_none_when_argument_is_unknown()
            {
                var parser = new AssociationCategoryParser();

                var result = parser.ParseProperty("XYZ");
                Assert.AreEqual(AssociationCategory.None, result);
            }
        }
    }
}
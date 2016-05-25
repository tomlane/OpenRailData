using System;
using NUnit.Framework;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TAssociationCategoryParser
    {
        [TestFixture]
        class ParseAssociationCategory
        {
            private AssociationCategoryParser BuildParser()
            {
                return new AssociationCategoryParser();
            }

            [Test]
            public void throws_when_argument_is_invalid()
            {
                var parser = BuildParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            }

            [Test]
            [TestCase("JJ", AssociationCategory.JJ)]
            [TestCase("VV", AssociationCategory.VV)]
            [TestCase("NP", AssociationCategory.NP)]
            public void returns_expected_result_when_valid(string value, AssociationCategory expectedResult)
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

                Assert.AreEqual(AssociationCategory.None, result);
            }
        }
    }
}
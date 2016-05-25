using System;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    
    public class TAssociationCategoryParser
    {
        class ParseAssociationCategory
        {
            private AssociationCategoryParser BuildParser()
            {
                return new AssociationCategoryParser();
            }

            [Fact]
            public void throws_when_argument_is_invalid()
            {
                var parser = BuildParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            }

            [Theory]
            [InlineData("JJ", AssociationCategory.JJ)]
            [InlineData("VV", AssociationCategory.VV)]
            [InlineData("NP", AssociationCategory.NP)]
            public void returns_expected_result_when_valid(string value, AssociationCategory expectedResult)
            {
                var parser = BuildParser();

                var result = parser.ParseProperty(value);

                Assert.Equal(expectedResult, result);
            }

            [Fact]
            public void returns_none_when_argument_is_unknown()
            {
                var parser = BuildParser();

                var result = parser.ParseProperty("XYZ");

                Assert.Equal(AssociationCategory.None, result);
            }
        }
    }
}
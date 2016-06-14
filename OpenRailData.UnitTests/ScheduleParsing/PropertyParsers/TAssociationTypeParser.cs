using System;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.ScheduleParsing.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    public class TAssociationTypeParser
    {
        private AssociationTypeParser BuildParser()
        {
            return new AssociationTypeParser();
        }

        [Fact]
        public void throws_when_argument_is_invalid()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Theory]
        [InlineData("P", AssociationType.P)]
        [InlineData("O", AssociationType.O)]
        public void returns_expected_result_when_valid(string value, AssociationType expectedResult)
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
            Assert.Equal(AssociationType.None, result);

        }
    }
}
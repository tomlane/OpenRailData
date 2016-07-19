using System;
using OpenRailData.Schedule.Entities.Enums;
using OpenRailData.Schedule.ScheduleParsing.PropertyParsers;
using Xunit;

namespace OpenRailData.UnitTests.ScheduleParsing.PropertyParsers
{
    
    public class TTransactionTypeParser
    {
        private TransactionTypeParser BuildParser()
        {
            return new TransactionTypeParser();
        }

        [Fact]
        public void throws_when_argument_is_invalid()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(string.Empty));
            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(" \t"));
        }

        [Theory]
        [InlineData("N", TransactionType.N)]
        [InlineData("R", TransactionType.R)]
        [InlineData("D", TransactionType.D)]
        public void returns_correct_values_from_cif_records(string value, TransactionType expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void returns_unknown_when_argument_is_unknown()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentException>(() => parser.ParseProperty("Z"));
        }
    }
}
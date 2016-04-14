using System;
using NUnit.Framework;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;
using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TTransactionTypeParser
    {
        private TransactionTypeParser BuildParser()
        {
            return new TransactionTypeParser();
        }

        [Test]
        public void throws_when_argument_is_invalid()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(string.Empty));
            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(" \t"));
        }

        [Test]
        [TestCase("N", TransactionType.N)]
        [TestCase("R", TransactionType.R)]
        [TestCase("D", TransactionType.D)]
        public void returns_correct_values_from_cif_records(string value, TransactionType expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void returns_unknown_when_argument_is_unknown()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentException>(() => parser.ParseProperty("Z"));
        }
    }
}
using System;
using NetworkRail.CifParser.Parsers;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.Parsers
{
    [TestFixture]
    public class TRawMessageDateTimeParser
    {
        [Test]
        public void returns_null_when_argument_is_null_or_empty()
        {
            var parser = new DateTimeParser();

            var result = parser.ParseDateTimeYYMMDD(null);
            Assert.IsNull(result);

            result = parser.ParseDateTimeYYMMDD(string.Empty);
            Assert.IsNull(result);

            result = parser.ParseDateTimeYYMMDD("\t ");
            Assert.IsNull(result);
        }

        [Test]
        public void returns_null_when_argument_is_invalid_date()
        {
            var parser = new DateTimeParser();

            var result = parser.ParseDateTimeYYMMDD("clearly not a date");
            Assert.IsNull(result);
        }

        [Test]
        public void returns_expected_date_when_argument_is_valid()
        {
            var parser = new DateTimeParser();

            var result = parser.ParseDateTimeYYMMDD("931111");
            Assert.AreEqual(new DateTime(1993, 11, 11), result);
        }
    }
}
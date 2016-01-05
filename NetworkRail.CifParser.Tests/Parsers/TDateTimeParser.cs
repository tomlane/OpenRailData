using System;
using NetworkRail.CifParser.Parsers;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.Parsers
{
    [TestFixture]
    public class TDateTimeParser
    {
        [TestFixture]
        class ParseNullableDateTime
        {
            [Test]
            public void returns_null_when_argument_is_null_or_empty()
            {
                var parser = new DateTimeParser();

                var result = parser.ParseNullableDateTime(null);
                Assert.IsNull(result);

                result = parser.ParseNullableDateTime(new DateTimeParserRequest());
                Assert.IsNull(result);
            }

            [Test]
            public void returns_null_when_argument_is_invalid_date()
            {
                var parser = new DateTimeParser();

                var result = parser.ParseNullableDateTime(new DateTimeParserRequest
                {
                    DateTimeString = "clearly not a date",
                    DateTimeFormat = "yymmdd"
                });

                Assert.IsNull(result);
            }

            [Test]
            public void returns_expected_date_when_argument_is_valid()
            {
                var parser = new DateTimeParser();

                var result = parser.ParseNullableDateTime(new DateTimeParserRequest
                {
                    DateTimeFormat = "yymmdd",
                    DateTimeString = "931111"
                });

                Assert.AreEqual(new DateTime(1993, 11, 11), result);
            }
        }


        
    }
}
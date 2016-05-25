using System;
using NUnit.Framework;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TDateTimeParser
    {
        private DateTimeParser BuildParser()
        {
            return new DateTimeParser();
        }

        [Test]
        public void throws_when_request_is_null()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseDateTime(null));
        }

        [Test]
        public void throws_when_request_format_is_null()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeString = "something something"
            }));
        }

        [Test]
        public void returns_null_when_datetime_string_is_empty()
        {
            var parser = BuildParser();

            var result = parser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "yyMMdd"
            });

            Assert.IsNull(result);
        }

        [Test]
        public void returns_null_when_argument_is_invalid_date()
        {
            var parser = BuildParser();

            var result = parser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeString = "clearly not a date",
                DateTimeFormat = "yyMMdd"
            });

            Assert.IsNull(result);
        }

        [Test]
        public void returns_expected_date_when_argument_is_valid()
        {
            var parser = BuildParser();

            var result = parser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "yyMMdd",
                DateTimeString = "931111"
            });

            Assert.AreEqual(new DateTime(1993, 11, 11), result);
        }

        [Test]
        public void returns_expected_year_from_spec()
        {
            // year should be 19xx if > 60 and 20xx if < 60
            var parser = BuildParser();

            var result = parser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "yyMMdd",
                DateTimeString = "931111"
            });

            Assert.AreEqual(1993, result.Value.Year);

            result = parser.ParseDateTime(new DateTimeParserRequest
            {
                DateTimeFormat = "yyMMdd",
                DateTimeString = "501111"
            });

            Assert.AreEqual(2050, result.Value.Year);
        }
    }
}

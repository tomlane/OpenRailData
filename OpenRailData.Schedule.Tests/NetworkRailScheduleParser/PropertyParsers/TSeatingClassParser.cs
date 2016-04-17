using System;
using NUnit.Framework;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TSeatingClassParser
    {
        private SeatingClassParser BuildParser()
        {
            return new SeatingClassParser();
        }

        [Test]
        public void throws_when_argument_is_null()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Test]
        public void returns_expected_result_when_argument_string_is_empty()
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(string.Empty);

            Assert.AreEqual(SeatingClass.B, result);
        }

        [Test]
        [TestCase("S", SeatingClass.S)]
        [TestCase("B", SeatingClass.B)]
        public void returns_expected_result_when_argument_is_not_empty(string value, SeatingClass expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
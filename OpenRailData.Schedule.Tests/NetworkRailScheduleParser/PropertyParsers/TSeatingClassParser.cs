using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TSeatingClassParser
    {
        [TestFixture]
        class ParseSeatingClass
        {
            [Test]
            public void throws_when_argument_is_null()
            {
                var parser = new SeatingClassParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            }

            [Test]
            public void returns_expected_result_when_argument_string_is_empty()
            {
                var parser = new SeatingClassParser();

                var result = parser.ParseProperty(string.Empty);

                Assert.AreEqual(SeatingClass.B, result);
            }

            [Test]
            [TestCase("S", SeatingClass.S)]
            [TestCase("B", SeatingClass.B)]
            public void returns_expected_result_when_argument_is_not_empty(string value, SeatingClass expectedResult)
            {
                var parser = new SeatingClassParser();

                var result = parser.ParseProperty(value);

                Assert.AreEqual(expectedResult, result);
            }
        }
    }
}
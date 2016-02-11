using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TExtractUpdateTypeParser
    {
        [TestFixture]
        class ParseExtractUpdateType
        {
            [Test]
            public void throws_when_argument_is_null_or_invalid()
            {
                var parser = new ExtractUpdateTypeParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(string.Empty));
                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(" \t"));
            }

            [Test]
            [TestCase("F", ExtractUpdateType.F)]
            [TestCase("U", ExtractUpdateType.U)]
            public void returns_expected_result_when_argument_is_valid(string value, ExtractUpdateType expectedResult)
            {
                var parser = new ExtractUpdateTypeParser();

                var result = parser.ParseProperty(value);

                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void throws_when_argument_is_unknown()
            {
                var parser = new ExtractUpdateTypeParser();

                Assert.Throws<ArgumentException>(() => parser.ParseProperty("Z"));
            }
        }
    }
}
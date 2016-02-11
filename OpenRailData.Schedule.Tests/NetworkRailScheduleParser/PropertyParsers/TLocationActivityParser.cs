using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TLocationActivityParser
    {
        [TestFixture]
        class ParseLocationActivity
        {
            [Test]
            public void throws_if_argument_string_is_null()
            {
                var parser = new LocationActivityParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            }

            [Test]
            // an example of each for sanity...
            [TestCase("A ", LocationActivity.A)]
            [TestCase("BL", LocationActivity.BL)]
            [TestCase("-D", LocationActivity.MinusD)]
            public void returns_expected_result(string value, LocationActivity expectedResult)
            {
                var parser = new LocationActivityParser();
                
                var result = parser.ParseProperty(value);
                
                Assert.IsTrue(result.HasFlag(expectedResult));
            }
        }
    }
}
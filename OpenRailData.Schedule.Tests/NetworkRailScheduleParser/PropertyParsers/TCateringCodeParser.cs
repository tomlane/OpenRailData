using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TCateringCodeParser
    {
        private CateringCodeParser BuildParser()
        {
            return new CateringCodeParser();
        }

        [Test]
        public void throws_if_argument_string_is_null()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Test]
        [TestCase("C", CateringCode.C)]
        [TestCase("F", CateringCode.F)]
        [TestCase("H", CateringCode.H)]
        [TestCase("M", CateringCode.M)]
        [TestCase("P", CateringCode.P)]
        [TestCase("R", CateringCode.R)]
        [TestCase("T", CateringCode.T)]
        public void returns_expected_result(string value, CateringCode expectedResult)
        {
            var parser = BuildParser();
            
            var result = parser.ParseProperty(value);

            Assert.IsTrue(result.HasFlag(expectedResult));
        }
    }
}
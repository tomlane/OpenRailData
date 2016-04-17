using System;
using NUnit.Framework;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TTrainSleeperDetailsParser
    {
        [TestFixture]
        class ParseTrainSleeperDetails
        {
            [Test]
            public void throws_when_argument_is_null_or_empty()
            {
                var parser = new SleeperDetailsParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            }

            [Test]
            [TestCase("B", SleeperDetails.B)]
            [TestCase("F", SleeperDetails.F)]
            [TestCase("S", SleeperDetails.S)]
            public void returns_expected_result_from_argument(string value, SleeperDetails expectedResult)
            {
                var parser = new SleeperDetailsParser();

                var result = parser.ParseProperty(value);

                Assert.AreEqual(expectedResult, result);
            }

            [Test]
            public void returns_not_available_when_argument_is_unknown()
            {
                var parser = new SleeperDetailsParser();

                var result = parser.ParseProperty("zzz");

                Assert.AreEqual(SleeperDetails.NotAvailable, result);
            }
        }
    }
}
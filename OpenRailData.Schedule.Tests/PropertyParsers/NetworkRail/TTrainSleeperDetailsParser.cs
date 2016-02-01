using System;
using NUnit.Framework;
using OpenRailData.Schedule.PropertyParsers.NetworkRail;
using OpenRailData.Schedule.Records.NetworkRail.Enums;

namespace OpenRailData.Schedule.Tests.PropertyParsers.NetworkRail
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
            public void returns_expected_result_from_argument()
            {
                var parser = new SleeperDetailsParser();

                var result = parser.ParseProperty("B");
                Assert.AreEqual(SleeperDetails.B, result);

                result = parser.ParseProperty("F");
                Assert.AreEqual(SleeperDetails.F, result);

                result = parser.ParseProperty("S");
                Assert.AreEqual(SleeperDetails.S, result);
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
using System;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordPropertyParsers
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

                Assert.Throws<ArgumentNullException>(() => parser.ParseTrainSleeperDetails(null));
            }

            [Test]
            public void returns_expected_result_from_argument()
            {
                var parser = new SleeperDetailsParser();

                var result = parser.ParseTrainSleeperDetails("B");
                Assert.AreEqual(SleeperDetails.FirstAndStandard, result);

                result = parser.ParseTrainSleeperDetails("F");
                Assert.AreEqual(SleeperDetails.FirstClassOnly, result);

                result = parser.ParseTrainSleeperDetails("S");
                Assert.AreEqual(SleeperDetails.StandardClassOnly, result);
            }

            [Test]
            public void returns_not_available_when_argument_is_unknown()
            {
                var parser = new SleeperDetailsParser();

                var result = parser.ParseTrainSleeperDetails("zzz");

                Assert.AreEqual(SleeperDetails.NotAvailable, result);
            }
        }
    }
}
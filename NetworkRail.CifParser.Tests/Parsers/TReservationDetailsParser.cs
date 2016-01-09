using System;
using NetworkRail.CifParser.Parsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.Parsers
{
    [TestFixture]
    public class TReservationDetailsParser
    {
        [TestFixture]
        class ParseTrainReservationDetails
        {
            [Test]
            public void throws_when_string_is_null()
            {
                var parser = new ReservationsDetailsParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseTrainResevationDetails(null));
            }

            [Test]
            public void returns_expected_result_from_argument()
            {
                var parser = new ReservationsDetailsParser();

                var result = parser.ParseTrainResevationDetails("A");
                Assert.AreEqual(ReservationDetails.Compulsory, result);

                result = parser.ParseTrainResevationDetails("E");
                Assert.AreEqual(ReservationDetails.BicyclesEssential, result);

                result = parser.ParseTrainResevationDetails("R");
                Assert.AreEqual(ReservationDetails.Recommended, result);

                result = parser.ParseTrainResevationDetails("S");
                Assert.AreEqual(ReservationDetails.PossibleFromAnyStation, result);
            }

            [Test]
            public void returns_none_when_argument_is_unknown()
            {
                var parser = new ReservationsDetailsParser();

                var result = parser.ParseTrainResevationDetails(" ");

                Assert.AreEqual(ReservationDetails.None, result);
            }
        }
    }
}
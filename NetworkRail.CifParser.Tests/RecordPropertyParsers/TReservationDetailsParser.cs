using System;
using NetworkRail.CifParser.RecordPropertyParsers;
using NetworkRail.CifParser.Records.Enums;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.RecordPropertyParsers
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
                var parser = new ReservationDetailsParser();

                Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
            }

            [Test]
            public void returns_expected_result_from_argument()
            {
                var parser = new ReservationDetailsParser();

                var result = parser.ParseProperty("A");
                Assert.AreEqual(ReservationDetails.Compulsory, result);

                result = parser.ParseProperty("E");
                Assert.AreEqual(ReservationDetails.BicyclesEssential, result);

                result = parser.ParseProperty("R");
                Assert.AreEqual(ReservationDetails.Recommended, result);

                result = parser.ParseProperty("S");
                Assert.AreEqual(ReservationDetails.PossibleFromAnyStation, result);
            }

            [Test]
            public void returns_none_when_argument_is_unknown()
            {
                var parser = new ReservationDetailsParser();

                var result = parser.ParseProperty(" ");

                Assert.AreEqual(ReservationDetails.None, result);
            }
        }
    }
}
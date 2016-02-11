using System;
using NUnit.Framework;
using OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.Tests.PropertyParsers.NetworkRail
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
                Assert.AreEqual(ReservationDetails.A, result);

                result = parser.ParseProperty("E");
                Assert.AreEqual(ReservationDetails.E, result);

                result = parser.ParseProperty("R");
                Assert.AreEqual(ReservationDetails.R, result);

                result = parser.ParseProperty("S");
                Assert.AreEqual(ReservationDetails.S, result);
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
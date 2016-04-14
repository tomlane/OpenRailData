using System;
using NUnit.Framework;
using OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers;
using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;

namespace OpenRailData.Schedule.Tests.NetworkRailScheduleParser.PropertyParsers
{
    [TestFixture]
    public class TReservationDetailsParser
    {
        private ReservationDetailsParser BuildParser()
        {
            return new ReservationDetailsParser();
        }

        [Test]
        public void throws_when_string_is_null()
        {
            var parser = BuildParser();

            Assert.Throws<ArgumentNullException>(() => parser.ParseProperty(null));
        }

        [Test]
        [TestCase("A", ReservationDetails.A)]
        [TestCase("E", ReservationDetails.E)]
        [TestCase("R", ReservationDetails.R)]
        [TestCase("S", ReservationDetails.S)]
        public void returns_expected_result_from_argument(string value, ReservationDetails expectedResult)
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(value);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void returns_none_when_argument_is_unknown()
        {
            var parser = BuildParser();

            var result = parser.ParseProperty(" ");

            Assert.AreEqual(ReservationDetails.None, result);
        }
    }
}
using System;
using Moq;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.Parsers;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.ParserContainers
{
    [TestFixture]
    public class TChangesEnRouteRecordParserContainer
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var seatingClassParserMock = new Mock<ISeatingClassParser>();
            var sleeperDetailsParserMock = new Mock<ISleeperDetailsParser>();
            var reservationDetailsParserMock = new Mock<IReservationDetailsParser>();

            Assert.Throws<ArgumentNullException>(() => new ChangesEnRouteRecordParserContainer(null, sleeperDetailsParserMock.Object, reservationDetailsParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new ChangesEnRouteRecordParserContainer(seatingClassParserMock.Object, null, reservationDetailsParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new ChangesEnRouteRecordParserContainer(seatingClassParserMock.Object, sleeperDetailsParserMock.Object, null));
        }

        [Test]
        public void returns_expected_result()
        {
            var seatingClassParserMock = new Mock<ISeatingClassParser>();
            var sleeperDetailsParserMock = new Mock<ISleeperDetailsParser>();
            var reservationDetailsParserMock = new Mock<IReservationDetailsParser>();

            var container = new ChangesEnRouteRecordParserContainer(seatingClassParserMock.Object, sleeperDetailsParserMock.Object, reservationDetailsParserMock.Object);

            Assert.AreEqual(seatingClassParserMock.Object, container.SeatingClassParser);
            Assert.AreEqual(sleeperDetailsParserMock.Object, container.SleeperDetailsParser);
            Assert.AreEqual(reservationDetailsParserMock.Object, container.ReservationDetailsParser);
        }
    }
}
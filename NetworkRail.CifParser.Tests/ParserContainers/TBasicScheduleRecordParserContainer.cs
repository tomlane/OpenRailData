using System;
using Moq;
using NetworkRail.CifParser.ParserContainers;
using NetworkRail.CifParser.RecordPropertyParsers;
using NUnit.Framework;

namespace NetworkRail.CifParser.Tests.ParserContainers
{
    [TestFixture]
    public class TBasicScheduleRecordParserContainer
    {
        [Test]
        public void throws_when_dependencies_are_null()
        {
            var transactionTypeParserMock = new Mock<ITransactionTypeParser>();
            var runningDaysParserMock = new Mock<IRunningDaysParser>();
            var bankHolidayRunningParserMock = new Mock<IBankHolidayRunningParser>();
            var operatingCharacteristicsParserMock = new Mock<IOperatingCharacteristicsParser>();
            var seatingClassParserMock = new Mock<ISeatingClassParser>();
            var sleeperDetailsParserMock = new Mock<ISleeperDetailsParser>();
            var reservationDetailsParserMock = new Mock<IReservationDetailsParser>();
            var stpIndicatorParserMock = new Mock<IStpIndicatorParser>();
            var dateTimeParserMock = new Mock<IDateTimeParser>();

            Assert.Throws<ArgumentNullException>(() => new BasicScheduleRecordParserContainer(null, runningDaysParserMock.Object, bankHolidayRunningParserMock.Object, operatingCharacteristicsParserMock.Object, seatingClassParserMock.Object, sleeperDetailsParserMock.Object, reservationDetailsParserMock.Object, stpIndicatorParserMock.Object, dateTimeParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new BasicScheduleRecordParserContainer(transactionTypeParserMock.Object, null, bankHolidayRunningParserMock.Object, operatingCharacteristicsParserMock.Object, seatingClassParserMock.Object, sleeperDetailsParserMock.Object, reservationDetailsParserMock.Object, stpIndicatorParserMock.Object, dateTimeParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new BasicScheduleRecordParserContainer(transactionTypeParserMock.Object, runningDaysParserMock.Object, null, operatingCharacteristicsParserMock.Object, seatingClassParserMock.Object, sleeperDetailsParserMock.Object, reservationDetailsParserMock.Object, stpIndicatorParserMock.Object, dateTimeParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new BasicScheduleRecordParserContainer(transactionTypeParserMock.Object, runningDaysParserMock.Object, bankHolidayRunningParserMock.Object, null, seatingClassParserMock.Object, sleeperDetailsParserMock.Object, reservationDetailsParserMock.Object, stpIndicatorParserMock.Object, dateTimeParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new BasicScheduleRecordParserContainer(transactionTypeParserMock.Object, runningDaysParserMock.Object, bankHolidayRunningParserMock.Object, operatingCharacteristicsParserMock.Object, null, sleeperDetailsParserMock.Object, reservationDetailsParserMock.Object, stpIndicatorParserMock.Object, dateTimeParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new BasicScheduleRecordParserContainer(transactionTypeParserMock.Object, runningDaysParserMock.Object, bankHolidayRunningParserMock.Object, operatingCharacteristicsParserMock.Object, seatingClassParserMock.Object, null, reservationDetailsParserMock.Object, stpIndicatorParserMock.Object, dateTimeParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new BasicScheduleRecordParserContainer(transactionTypeParserMock.Object, runningDaysParserMock.Object, bankHolidayRunningParserMock.Object, operatingCharacteristicsParserMock.Object, seatingClassParserMock.Object, sleeperDetailsParserMock.Object, null, stpIndicatorParserMock.Object, dateTimeParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new BasicScheduleRecordParserContainer(transactionTypeParserMock.Object, runningDaysParserMock.Object, bankHolidayRunningParserMock.Object, operatingCharacteristicsParserMock.Object, seatingClassParserMock.Object, sleeperDetailsParserMock.Object, reservationDetailsParserMock.Object, null, dateTimeParserMock.Object));
            Assert.Throws<ArgumentNullException>(() => new BasicScheduleRecordParserContainer(transactionTypeParserMock.Object, runningDaysParserMock.Object, bankHolidayRunningParserMock.Object, operatingCharacteristicsParserMock.Object, seatingClassParserMock.Object, sleeperDetailsParserMock.Object, reservationDetailsParserMock.Object, stpIndicatorParserMock.Object, null));
        }

        [Test]
        public void returns_expected_result()
        {
            var transactionTypeParserMock = new Mock<ITransactionTypeParser>();
            var runningDaysParserMock = new Mock<IRunningDaysParser>();
            var bankHolidayRunningParserMock = new Mock<IBankHolidayRunningParser>();
            var operatingCharacteristicsParserMock = new Mock<IOperatingCharacteristicsParser>();
            var seatingClassParserMock = new Mock<ISeatingClassParser>();
            var sleeperDetailsParserMock = new Mock<ISleeperDetailsParser>();
            var reservationDetailsParserMock = new Mock<IReservationDetailsParser>();
            var stpIndicatorParserMock = new Mock<IStpIndicatorParser>();
            var dateTimeParserMock = new Mock<IDateTimeParser>();

            var container = new BasicScheduleRecordParserContainer(transactionTypeParserMock.Object,
                runningDaysParserMock.Object, bankHolidayRunningParserMock.Object,
                operatingCharacteristicsParserMock.Object, seatingClassParserMock.Object,
                sleeperDetailsParserMock.Object, reservationDetailsParserMock.Object, stpIndicatorParserMock.Object, dateTimeParserMock.Object);

            Assert.AreEqual(transactionTypeParserMock.Object, container.TransactionTypeParser);
            Assert.AreEqual(runningDaysParserMock.Object, container.RunningDaysParser);
            Assert.AreEqual(bankHolidayRunningParserMock.Object, container.BankHolidayRunningParser);
            Assert.AreEqual(operatingCharacteristicsParserMock.Object, container.OperatingCharacteristicsParser);
            Assert.AreEqual(seatingClassParserMock.Object, container.SeatingClassParser);
            Assert.AreEqual(sleeperDetailsParserMock.Object, container.SleeperDetailsParser);
            Assert.AreEqual(reservationDetailsParserMock.Object, container.ReservationDetailsParser);
            Assert.AreEqual(stpIndicatorParserMock.Object, container.StpIndicatorParser);
            Assert.AreEqual(dateTimeParserMock.Object, container.DateTimeParser);
        }
    }
}
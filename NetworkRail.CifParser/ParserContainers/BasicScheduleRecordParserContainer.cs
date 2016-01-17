using System;
using NetworkRail.CifParser.Parsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public class BasicScheduleRecordParserContainer : IBasicScheduleRecordParserContainer
    {
        public ITransactionTypeParser TransactionTypeParser { get; }
        public IRunningDaysParser RunningDaysParser { get; }
        public IBankHolidayRunningParser BankHolidayRunningParser { get; }
        public IOperatingCharacteristicsParser OperatingCharacteristicsParser { get; }
        public ISeatingClassParser SeatingClassParser { get; }
        public ISleeperDetailsParser SleeperDetailsParser { get; }
        public IReservationDetailsParser ReservationDetailsParser { get; }
        public IStpIndicatorParser StpIndicatorParser { get; }
        public IDateTimeParser DateTimeParser { get; }

        public BasicScheduleRecordParserContainer(ITransactionTypeParser transactionTypeParser, IRunningDaysParser runningDaysParser, IBankHolidayRunningParser bankHolidayRunningParser, IOperatingCharacteristicsParser operatingCharacteristicsParser, ISeatingClassParser seatingClassParser, ISleeperDetailsParser sleeperDetailsParser, IReservationDetailsParser reservationDetailsParser, IStpIndicatorParser stpIndicatorParser, IDateTimeParser dateTimeParser)
        {
            if (transactionTypeParser == null)
                throw new ArgumentNullException(nameof(transactionTypeParser));
            if (runningDaysParser == null)
                throw new ArgumentNullException(nameof(runningDaysParser));
            if (bankHolidayRunningParser == null)
                throw new ArgumentNullException(nameof(bankHolidayRunningParser));
            if (operatingCharacteristicsParser == null)
                throw new ArgumentNullException(nameof(operatingCharacteristicsParser));
            if (seatingClassParser == null)
                throw new ArgumentNullException(nameof(seatingClassParser));
            if (sleeperDetailsParser == null)
                throw new ArgumentNullException(nameof(sleeperDetailsParser));
            if (reservationDetailsParser == null)
                throw new ArgumentNullException(nameof(reservationDetailsParser));
            if (stpIndicatorParser == null)
                throw new ArgumentNullException(nameof(stpIndicatorParser));
            if (dateTimeParser == null)
                throw new ArgumentNullException(nameof(dateTimeParser));

            TransactionTypeParser = transactionTypeParser;
            RunningDaysParser = runningDaysParser;
            BankHolidayRunningParser = bankHolidayRunningParser;
            OperatingCharacteristicsParser = operatingCharacteristicsParser;
            SeatingClassParser = seatingClassParser;
            SleeperDetailsParser = sleeperDetailsParser;
            ReservationDetailsParser = reservationDetailsParser;
            StpIndicatorParser = stpIndicatorParser;
            DateTimeParser = dateTimeParser;
        }
    }
}
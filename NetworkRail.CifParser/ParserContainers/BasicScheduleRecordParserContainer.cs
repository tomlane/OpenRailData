using System;
using NetworkRail.CifParser.Parsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public class BasicScheduleRecordParserContainer : IBasicScheduleRecordParserContainer
    {
        public ITransactionTypeParser TransactionTypeParser { get; set; }
        public IRunningDaysParser RunningDaysParser { get; set; }
        public IBankHolidayRunningParser BankHolidayRunningParser { get; set; }
        public IOperatingCharacteristicsParser OperatingCharacteristicsParser { get; set; }
        public ISeatingClassParser SeatingClassParser { get; set; }
        public ISleeperDetailsParser SleeperDetailsParser { get; set; }
        public IReservationDetailsParser ReservationDetailsParser { get; set; }
        public IStpIndicatorParser StpIndicatorParser { get; set; }

        public BasicScheduleRecordParserContainer(ITransactionTypeParser transactionTypeParser, IRunningDaysParser runningDaysParser, IBankHolidayRunningParser bankHolidayRunningParser, IOperatingCharacteristicsParser operatingCharacteristicsParser, ISeatingClassParser seatingClassParser, ISleeperDetailsParser sleeperDetailsParser, IReservationDetailsParser reservationDetailsParser, IStpIndicatorParser stpIndicatorParser)
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

            TransactionTypeParser = transactionTypeParser;
            RunningDaysParser = runningDaysParser;
            BankHolidayRunningParser = bankHolidayRunningParser;
            OperatingCharacteristicsParser = operatingCharacteristicsParser;
            SeatingClassParser = seatingClassParser;
            SleeperDetailsParser = sleeperDetailsParser;
            ReservationDetailsParser = reservationDetailsParser;
            StpIndicatorParser = stpIndicatorParser;
        }
    }
}
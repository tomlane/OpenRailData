using NetworkRail.CifParser.RecordPropertyParsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public interface IBasicScheduleRecordParserContainer
    {
        ITransactionTypeParser TransactionTypeParser { get; }
        IRunningDaysParser RunningDaysParser { get; }
        IBankHolidayRunningParser BankHolidayRunningParser { get; }
        IOperatingCharacteristicsParser OperatingCharacteristicsParser { get; }
        ISeatingClassParser SeatingClassParser { get; }
        ISleeperDetailsParser SleeperDetailsParser { get; }
        IReservationDetailsParser ReservationDetailsParser { get; }
        IStpIndicatorParser StpIndicatorParser { get; }
        IDateTimeParser DateTimeParser { get; }
    }
}
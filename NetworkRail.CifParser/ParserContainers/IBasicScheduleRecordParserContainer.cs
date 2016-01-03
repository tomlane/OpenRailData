using NetworkRail.CifParser.Parsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public interface IBasicScheduleRecordParserContainer
    {
        ITransactionTypeParser TransactionTypeParser { get; set; }
        IRunningDaysParser RunningDaysParser { get; set; }
        IBankHolidayRunningParser BankHolidayRunningParser { get; set; }
        IOperatingCharacteristicsParser OperatingCharacteristicsParser { get; set; }
        ISeatingClassParser SeatingClassParser { get; set; }
        ISleeperDetailsParser SleeperDetailsParser { get; set; }
        IReservationDetailsParser ReservationDetailsParser { get; set; }
        IStpIndicatorParser StpIndicatorParser { get; set; }
    }
}
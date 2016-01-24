using NetworkRail.CifParser.RecordPropertyParsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public interface IAssociationRecordParserContainer
    {
        ITransactionTypeParser TransactionTypeParser { get; }
        IDateTimeParser DateTimeParser { get; }
        IRunningDaysParser RunningDaysParser { get; }
        IAssociationCategoryParser AssociationCategoryParser { get; }
        IDateIndicatorParser DateIndicatorParser { get; }
        IAssociationTypeParser AssociationTypeParser { get; }
        IStpIndicatorParser StpIndicatorParser { get; }
    }
}
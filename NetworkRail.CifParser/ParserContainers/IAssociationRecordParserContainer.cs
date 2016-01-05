using NetworkRail.CifParser.Parsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public interface IAssociationRecordParserContainer
    {
        ITransactionTypeParser TransactionTypeParser { get; set; }
        IDateTimeParser DateTimeParser { get; set; }
        IRunningDaysParser RunningDaysParser { get; set; }
        IAssociationCategoryParser AssociationCategoryParser { get; set; }
        IDateIndicatorParser DateIndicatorParser { get; set; }
        IAssociationTypeParser AssociationTypeParser { get; set; }
        IStpIndicatorParser StpIndicatorParser { get; set; }
    }
}
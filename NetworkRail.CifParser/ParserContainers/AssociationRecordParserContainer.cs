using System;
using NetworkRail.CifParser.RecordPropertyParsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public class AssociationRecordParserContainer : IAssociationRecordParserContainer
    {
        public ITransactionTypeParser TransactionTypeParser { get; }
        public IDateTimeParser DateTimeParser { get; }
        public IRunningDaysParser RunningDaysParser { get; }
        public IAssociationCategoryParser AssociationCategoryParser { get; }
        public IDateIndicatorParser DateIndicatorParser { get; }
        public IAssociationTypeParser AssociationTypeParser { get; }
        public IStpIndicatorParser StpIndicatorParser { get; }

        public AssociationRecordParserContainer(ITransactionTypeParser transactionTypeParser, IDateTimeParser dateTimeParser, IRunningDaysParser runningDaysParser, IAssociationCategoryParser associationCategoryParser, IDateIndicatorParser dateIndicatorParser, IAssociationTypeParser associationTypeParser, IStpIndicatorParser stpIndicatorParser)
        {
            if (transactionTypeParser == null)
                throw new ArgumentNullException(nameof(transactionTypeParser));
            if (dateTimeParser == null)
                throw new ArgumentNullException(nameof(dateTimeParser));
            if (runningDaysParser == null)
                throw new ArgumentNullException(nameof(runningDaysParser));
            if (associationCategoryParser == null)
                throw new ArgumentNullException(nameof(associationCategoryParser));
            if (dateIndicatorParser == null)
                throw new ArgumentNullException(nameof(dateIndicatorParser));
            if (associationTypeParser == null)
                throw new ArgumentNullException(nameof(associationTypeParser));
            if (stpIndicatorParser == null)
                throw new ArgumentNullException(nameof(stpIndicatorParser));

            TransactionTypeParser = transactionTypeParser;
            DateTimeParser = dateTimeParser;
            RunningDaysParser = runningDaysParser;
            AssociationCategoryParser = associationCategoryParser;
            DateIndicatorParser = dateIndicatorParser;
            AssociationTypeParser = associationTypeParser;
            StpIndicatorParser = stpIndicatorParser;
        }
    }
}
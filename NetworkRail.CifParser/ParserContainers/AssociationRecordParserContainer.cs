using System;
using NetworkRail.CifParser.Parsers;

namespace NetworkRail.CifParser.ParserContainers
{
    public class AssociationRecordParserContainer : IAssociationRecordParserContainer
    {
        public ITransactionTypeParser TransactionTypeParser { get; set; }
        public IDateTimeParser DateTimeParser { get; set; }
        public IRunningDaysParser RunningDaysParser { get; set; }
        public IAssociationCategoryParser AssociationCategoryParser { get; set; }
        public IDateIndicatorParser DateIndicatorParser { get; set; }
        public IAssociationTypeParser AssociationTypeParser { get; set; }

        public AssociationRecordParserContainer(ITransactionTypeParser transactionTypeParser, IDateTimeParser dateTimeParser, IRunningDaysParser runningDaysParser, IAssociationCategoryParser associationCategoryParser, IDateIndicatorParser dateIndicatorParser, IAssociationTypeParser associationTypeParser)
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

            TransactionTypeParser = transactionTypeParser;
            DateTimeParser = dateTimeParser;
            RunningDaysParser = runningDaysParser;
            AssociationCategoryParser = associationCategoryParser;
            DateIndicatorParser = dateIndicatorParser;
            AssociationTypeParser = associationTypeParser;
        }
    }
}
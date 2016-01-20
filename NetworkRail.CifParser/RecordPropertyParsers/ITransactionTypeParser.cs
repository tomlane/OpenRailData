using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public interface ITransactionTypeParser
    {
        TransactionType ParseTransactionType(string transactionType);
    }
}
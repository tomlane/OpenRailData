using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public interface ITransactionTypeParser
    {
        TransactionType ParseTransactionType(string transactionType);
    }
}
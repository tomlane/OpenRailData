using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.Parsers
{
    public class TransactionTypeParser : ITransactionTypeParser
    {
        public TransactionType ParseTransactionType(string transactionType)
        {
            if (string.IsNullOrWhiteSpace(transactionType))
                throw new ArgumentNullException(nameof(transactionType));

            switch (transactionType)
            {
                case "N":
                    return TransactionType.New;
                case "R":
                    return TransactionType.Revise;
                case "D":
                    return TransactionType.Delete;
                default:
                    throw new ArgumentException($"Unknown transaction type: {transactionType}");
            }
        }
    }
}
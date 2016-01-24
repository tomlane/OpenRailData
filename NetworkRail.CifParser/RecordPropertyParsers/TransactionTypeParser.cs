using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public class TransactionTypeParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "TransactionType";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));
            
            return (TransactionType)Enum.Parse(typeof(TransactionType), propertyString);
        }
    }
}
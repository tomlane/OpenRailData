using System;
using OpenRailData.Schedule.Entities.Enums;

namespace OpenRailData.Schedule.ScheduleParsing.PropertyParsers
{
    public class TransactionTypeParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "TransactionType";

        public Enum ParseProperty(string propertyString)
        {
            if (string.IsNullOrWhiteSpace(propertyString))
                throw new ArgumentNullException(nameof(propertyString));
            
            return (TransactionType)Enum.Parse(typeof(TransactionType), propertyString);
        }
    }
}
using System;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers
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
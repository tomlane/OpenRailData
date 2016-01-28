using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public class SeatingClassParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "SeatingClass";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));
            
            if (propertyString.Trim() == string.Empty)
                return SeatingClass.B;
            
            return (SeatingClass)Enum.Parse(typeof(SeatingClass), propertyString);
        }
    }
}
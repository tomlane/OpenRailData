using System;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers
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
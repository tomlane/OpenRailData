using System;
using OpenRailData.Schedule.Records.NetworkRail.Enums;

namespace OpenRailData.Schedule.PropertyParsers.NetworkRail
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
using System;
using OpenRailData.Domain.ScheduleRecords.Enums;

namespace OpenRailData.ScheduleParsing.PropertyParsers
{
    public class SeatingClassParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "SeatingClass";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null || propertyString.Trim() == string.Empty)
                return SeatingClass.B;
            
            return (SeatingClass)Enum.Parse(typeof(SeatingClass), propertyString);
        }
    }
}
using System;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers
{
    public interface IRecordEnumPropertyParser
    {
        string PropertyKey { get; }
        Enum ParseProperty(string propertyString);
    }
}
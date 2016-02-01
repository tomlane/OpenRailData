using System;

namespace OpenRailData.Schedule.PropertyParsers.NetworkRail
{
    public interface IRecordEnumPropertyParser
    {
        string PropertyKey { get; }
        Enum ParseProperty(string propertyString);
    }
}
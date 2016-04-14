using System;

namespace OpenRailData.ScheduleParsing
{
    public interface IRecordEnumPropertyParser
    {
        string PropertyKey { get; }
        Enum ParseProperty(string propertyString);
    }
}
using System;

namespace OpenRailData.Schedule.ScheduleParsing
{
    public interface IRecordEnumPropertyParser
    {
        string PropertyKey { get; }
        Enum ParseProperty(string propertyString);
    }
}
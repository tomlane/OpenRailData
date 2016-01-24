using System;

namespace NetworkRail.CifParser.RecordPropertyParsers
{
    public interface IRecordEnumPropertyParser
    {
        string PropertyKey { get; }
        Enum ParseProperty(string propertyString);
    }
}
using System;
using OpenRailData.Schedule.Entities.Enums;

namespace OpenRailData.Schedule.ScheduleParsing.PropertyParsers
{
    public class ServiceBrandingParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "ServiceBranding";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                return ServiceBranding.None;

            ServiceBranding result;

            var successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : ServiceBranding.None;
        }
    }
}
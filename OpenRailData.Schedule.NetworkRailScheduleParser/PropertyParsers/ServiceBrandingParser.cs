using System;
using OpenRailData.Schedule.NetworkRailScheduleParser.Records.Enums;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.PropertyParsers
{
    public class ServiceBrandingParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "ServiceBranding";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            ServiceBranding result;

            bool successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : ServiceBranding.None;
        }
    }
}
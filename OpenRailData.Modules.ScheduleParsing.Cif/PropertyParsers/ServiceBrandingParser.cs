using System;
using OpenRailData.Domain.ScheduleRecords.Enums;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers
{
    public class ServiceBrandingParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "ServiceBranding";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            ServiceBranding result;

            var successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : ServiceBranding.None;
        }
    }
}
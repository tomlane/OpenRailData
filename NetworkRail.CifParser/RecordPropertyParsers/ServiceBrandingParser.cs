using System;
using NetworkRail.CifParser.Records.Enums;

namespace NetworkRail.CifParser.RecordPropertyParsers
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
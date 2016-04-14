using System;
using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers
{
    public class CateringCodeParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "CateringCode";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            propertyString = string.Join<char>(", ", propertyString.Trim());

            CateringCode result;

            var successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : 0;
        }
    }
}
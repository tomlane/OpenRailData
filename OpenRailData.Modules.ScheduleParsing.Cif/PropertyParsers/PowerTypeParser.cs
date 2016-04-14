using System;
using OpenRailData.Schedule.NetworkRailEntites.Records.Enums;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Modules.ScheduleParsing.Cif.PropertyParsers
{
    public class PowerTypeParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "PowerType";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            PowerType result;

            var successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : PowerType.None;
        }
    }
}
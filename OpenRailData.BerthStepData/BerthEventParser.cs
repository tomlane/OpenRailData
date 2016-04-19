using System;
using OpenRailData.Domain.ReferenceData;

namespace OpenRailData.BerthStepData
{
    public class BerthEventParser
    {
        public static Enum Parse(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            BerthEvent result;

            var successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : BerthEvent.Unknown;
        }
    }
}
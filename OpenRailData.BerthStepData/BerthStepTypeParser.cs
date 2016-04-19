using System;
using OpenRailData.Domain.ReferenceData;

namespace OpenRailData.BerthStepData
{
    public class BerthStepTypeParser
    {
        public static Enum Parse(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            BerthStepType result;

            var successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : BerthStepType.Unknown;
        }
    }
}
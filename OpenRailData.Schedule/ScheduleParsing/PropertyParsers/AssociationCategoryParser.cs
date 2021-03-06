﻿using System;
using OpenRailData.Schedule.Entities.Enums;

namespace OpenRailData.Schedule.ScheduleParsing.PropertyParsers
{
    public class AssociationCategoryParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "AssociationCategory";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            AssociationCategory result;

            var successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : AssociationCategory.None;
        }
    }
}
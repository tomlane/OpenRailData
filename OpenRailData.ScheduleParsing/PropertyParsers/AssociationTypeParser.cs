﻿using System;
using OpenRailData.Domain.ScheduleRecords.Enums;

namespace OpenRailData.ScheduleParsing.PropertyParsers
{
    public class AssociationTypeParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "AssociationType";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            AssociationType result;

            var successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : AssociationType.None;
        }
    }
}
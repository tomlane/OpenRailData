﻿using System;
using OpenRailData.Domain.ScheduleRecords.Enums;

namespace OpenRailData.ScheduleParsing.PropertyParsers
{
    public class CateringCodeParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "CateringCode";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                return CateringCode.None;

            propertyString = string.Join<char>(", ", propertyString.Trim());

            CateringCode result;

            var successful = Enum.TryParse(propertyString, true, out result);

            return successful ? result : 0;
        }
    }
}
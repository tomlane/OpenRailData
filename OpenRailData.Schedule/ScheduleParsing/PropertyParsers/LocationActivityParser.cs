﻿using System;
using System.Text;
using OpenRailData.Schedule.Entities.Enums;

namespace OpenRailData.Schedule.ScheduleParsing.PropertyParsers
{
    public class LocationActivityParser : IRecordEnumPropertyParser
    {
        public string PropertyKey { get; } = "LocationActivity";

        public Enum ParseProperty(string propertyString)
        {
            if (propertyString == null)
                throw new ArgumentNullException(nameof(propertyString));

            propertyString = propertyString.Trim();
            
            LocationActivity result = 0;

            if (propertyString == string.Empty)
                return result;

            var stringBuilder = new StringBuilder();

            for (var i = 0; i < propertyString.Length; i = i + 2)
            {
                string activity;

                try
                {
                    activity = propertyString.Substring(i, 2);
                }
                catch (ArgumentOutOfRangeException)
                {
                    activity = propertyString.Substring(i, 1);
                }

                stringBuilder.Append(activity);
                stringBuilder.Append(", ");
            }

            var builderString = stringBuilder.ToString().Replace("-", "Minus").Trim().TrimEnd(',');

            var successful = Enum.TryParse(builderString, true, out result);

            return successful ? result : 0;
        }
    }
}
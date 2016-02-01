﻿using System;
using OpenRailData.Schedule.NetworkRailScheduleParser;
using OpenRailData.Schedule.Records.NetworkRail;

namespace OpenRailData.Schedule.RecordParsers.NetworkRail.CifRecordParsers
{
    public class TiplocDeleteCifRecordParser : IScheduleRecordParser
    {
        public string RecordKey { get; } = "TD";

        public IScheduleRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            TiplocDeleteRecord record = new TiplocDeleteRecord
            {
                TiplocCode = recordString.Substring(2, 7).Trim()
            };
            
            return record;
        }
    }
}
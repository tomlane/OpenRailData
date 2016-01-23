﻿using System;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordParsers
{
    public class TiplocDeleteRecordParser : ICifRecordParser
    {
        public string RecordKey { get; } = "TD";

        public ICifRecord ParseRecord(string recordString)
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
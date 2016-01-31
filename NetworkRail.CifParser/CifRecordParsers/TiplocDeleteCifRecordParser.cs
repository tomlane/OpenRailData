using System;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.CifRecordParsers
{
    public class TiplocDeleteCifRecordParser : ICifRecordParser
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
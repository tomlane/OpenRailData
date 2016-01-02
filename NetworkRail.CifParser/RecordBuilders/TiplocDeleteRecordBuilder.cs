using System;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordBuilders
{
    public class TiplocDeleteRecordBuilder : ICifRecordBuilder<TiplocDeleteRecord>
    {
        public TiplocDeleteRecord BuildRecord(string recordString)
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
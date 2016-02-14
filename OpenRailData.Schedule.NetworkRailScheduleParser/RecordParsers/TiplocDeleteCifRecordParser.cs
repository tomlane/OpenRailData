using System;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordParsers
{
    public class TiplocDeleteCifRecordParser : IScheduleRecordParser
    {
        public string RecordKey { get; } = "TD";

        public IScheduleRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            var record = new TiplocRecord
            {
                RecordIdentity = ScheduleRecordType.TD,
                TiplocCode = recordString.Substring(2, 7).Trim()
            };
            
            return record;
        }
    }
}
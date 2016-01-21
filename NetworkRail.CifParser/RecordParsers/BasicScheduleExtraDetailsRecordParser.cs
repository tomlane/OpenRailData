using System;
using NetworkRail.CifParser.Records;

namespace NetworkRail.CifParser.RecordParsers
{
    public class BasicScheduleExtraDetailsRecordParser : ICifRecordParser<BasicScheduleExtraDetailsRecord>
    {
        public BasicScheduleExtraDetailsRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            BasicScheduleExtraDetailsRecord record = new BasicScheduleExtraDetailsRecord
            {
                RecordIdentity = CifRecordType.BasicScheduleExtraDetails,
                UicCode = recordString.Substring(6, 5).Trim(),
                AtocCode = recordString.Substring(11, 2).Trim(),
                AtsCode = recordString.Substring(13, 1).Trim(),
                Rsid = recordString.Substring(14, 8).Trim(),
                DataSource = recordString.Substring(22, 1).Trim()
            };

            return record;
        }
    }
}
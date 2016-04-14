using System;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Modules.ScheduleParsing.Cif.RecordParsers
{
    public class BasicScheduleExtraDetailsCifRecordParser : IScheduleRecordParser
    {
        public string RecordKey { get; } = "BX";

        public IScheduleRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            var record = new BasicScheduleExtraDetailsRecord
            {
                RecordIdentity = ScheduleRecordType.BX,

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
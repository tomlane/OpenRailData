using System;
using OpenRailData.Modules.ScheduleParsing.Cif.Utils;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Modules.ScheduleParsing.Cif.RecordParsers
{
    public class TiplocInsertCifRecordParser : IScheduleRecordParser
    {
        public string RecordKey { get; } = "TI";

        public IScheduleRecord ParseRecord(string recordString)
        {
            if (string.IsNullOrWhiteSpace(recordString))
                throw new ArgumentNullException(nameof(recordString));

            return new TiplocRecord
            {
                RecordIdentity = ScheduleRecordType.TI,
                TiplocCode = recordString.Substring(2, 7).Trim(),
                CapitalsIdentification = recordString.Substring(9, 2).Trim(),
                Nalco = recordString.Substring(11, 6).Trim(),
                Nlc = recordString.Substring(17, 1).Trim(),
                TpsDescription = recordString.Substring(18, 26).Trim().LocationCasing(),
                Stanox = recordString.Substring(44, 5).Trim(),
                PoMcbCode = recordString.Substring(49, 4).Trim(),
                CrsCode = recordString.Substring(53, 3).Trim(),
                CapriDescription = recordString.Substring(56, 16).Trim().LocationCasing()
            };
        }
    }
}
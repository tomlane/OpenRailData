using System;
using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleParsing.Cif.RecordParsers
{
    public class TiplocInsertCifRecordParser : IScheduleRecordParser
    {
        /// <summary>
        /// The schedule record key for this parser.
        /// </summary>
        public string RecordKey { get; } = "TI";

        /// <summary>
        /// Parses a record string in to a schedule record entity.
        /// </summary>
        /// <param name="recordString">The schedule record string.</param>
        /// <returns>A schedule record entity.</returns>
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
                TpsDescription = recordString.Substring(18, 26).Trim(),
                Stanox = recordString.Substring(44, 5).Trim(),
                PoMcbCode = recordString.Substring(49, 4).Trim(),
                CrsCode = recordString.Substring(53, 3).Trim(),
                CapriDescription = recordString.Substring(56, 16).Trim()
            };
        }
    }
}
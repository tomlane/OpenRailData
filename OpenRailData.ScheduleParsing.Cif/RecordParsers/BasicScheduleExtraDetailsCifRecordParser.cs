using System;
using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleParsing.Cif.RecordParsers
{
    public class BasicScheduleExtraDetailsCifRecordParser : IScheduleRecordParser
    {
        /// <summary>
        /// The schedule record key for this parser.
        /// </summary>
        public string RecordKey { get; } = "BX";

        /// <summary>
        /// Parses a record string in to a schedule record entity.
        /// </summary>
        /// <param name="recordString">The schedule record string.</param>
        /// <returns>A schedule record entity.</returns>
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
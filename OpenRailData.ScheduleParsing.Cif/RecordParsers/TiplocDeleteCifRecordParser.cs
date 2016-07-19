using System;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.ScheduleParsing;

namespace OpenRailData.ScheduleParsing.Cif.RecordParsers
{
    public class TiplocDeleteCifRecordParser : IScheduleRecordParser
    {
        /// <summary>
        /// The schedule record key for this parser.
        /// </summary>
        public string RecordKey { get; } = "TD";

        /// <summary>
        /// Parses a record string in to a schedule record entity.
        /// </summary>
        /// <param name="recordString">The schedule record string.</param>
        /// <returns>A schedule record entity.</returns>
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
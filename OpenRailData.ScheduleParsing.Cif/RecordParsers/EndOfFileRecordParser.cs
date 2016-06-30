using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleParsing.Cif.RecordParsers
{
    public class EndOfFileRecordParser : IScheduleRecordParser
    {
        /// <summary>
        /// The schedule record key for this parser.
        /// </summary>
        public string RecordKey { get; } = "ZZ";

        /// <summary>
        /// Parses a record string in to a schedule record entity.
        /// </summary>
        /// <param name="recordString">The schedule record string.</param>
        /// <returns>A schedule record entity.</returns>
        public IScheduleRecord ParseRecord(string recordString)
        {
            return new EndOfFileRecord
            {
                RecordIdentity = ScheduleRecordType.ZZ
            };
        }
    }
}
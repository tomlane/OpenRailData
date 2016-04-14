using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.ScheduleParsing;

namespace OpenRailData.Modules.ScheduleParsing.Cif.RecordParsers
{
    public class EndOfFileRecordParser : IScheduleRecordParser
    {
        public string RecordKey { get; } = "ZZ";

        public IScheduleRecord ParseRecord(string recordString)
        {
            return new EndOfFileRecord
            {
                RecordIdentity = ScheduleRecordType.ZZ
            };
        }
    }
}
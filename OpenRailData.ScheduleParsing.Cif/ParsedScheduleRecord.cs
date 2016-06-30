using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleParsing.Cif
{
    internal class ParsedScheduleRecord
    {
        public int Index { get; set; }
        public IScheduleRecord ScheduleRecord { get; set; }
    }
}
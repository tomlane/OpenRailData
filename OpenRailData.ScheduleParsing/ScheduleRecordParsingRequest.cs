using System.Collections.Generic;

namespace OpenRailData.ScheduleParsing
{
    public class ScheduleRecordParsingRequest
    {
        public string RecordType { get; set; }

        public IList<string> Records { get; set; }
    }
}
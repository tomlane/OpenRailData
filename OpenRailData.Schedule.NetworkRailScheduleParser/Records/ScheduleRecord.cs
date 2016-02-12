using System.Collections.Generic;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.Records
{
    public class ScheduleRecord : IScheduleRecord
    {
        public ScheduleRecordType RecordIdentity { get; set; }

        public BasicScheduleRecord Schedule { get; set; } = new BasicScheduleRecord();
        public List<IScheduleRecord> LocationRecords { get; } = new List<IScheduleRecord>();
    }
}
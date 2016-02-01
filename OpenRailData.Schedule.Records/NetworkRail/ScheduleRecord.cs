using System.Collections.Generic;

namespace OpenRailData.Schedule.Records.NetworkRail
{
    public class ScheduleRecord : IScheduleRecord
    {
        public ScheduleRecordType RecordIdentity { get; } = ScheduleRecordType.Schedule;

        public BasicScheduleRecord Schedule { get; set; } = new BasicScheduleRecord();
        public List<IScheduleRecord> LocationRecords { get; } = new List<IScheduleRecord>();
    }
}
using System;

namespace NetworkRail.CifParser.Records
{
    public class JsonHeaderRecord : IScheduleRecord
    {
        public ScheduleRecordType RecordIdentity { get; } = ScheduleRecordType.JsonHeader;

        public int Id { get; set; } = 0;
        public string Classification { get; set; } = string.Empty;
        public DateTime? Timestamp { get; set; }
        public string Owner { get; set; } = string.Empty;
        protected Sender Sender { get; set; } = new Sender();
        public MetaData MetaData { get; set; } = new MetaData();
    }

    public class MetaData
    {
        public string Type { get; set; } = string.Empty;
        public string Sequence { get; set; } = string.Empty;
    }

    public class Sender
    {
        public string Organisation { get; set; } = string.Empty;
        public string Application { get; set; } = string.Empty;
        public string Component { get; set; } = string.Empty;
    }
}

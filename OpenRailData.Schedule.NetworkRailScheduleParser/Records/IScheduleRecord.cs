namespace OpenRailData.Schedule.NetworkRailScheduleParser.Records
{
    public interface IScheduleRecord
    {
        ScheduleRecordType RecordIdentity { get; set; }
    }
}
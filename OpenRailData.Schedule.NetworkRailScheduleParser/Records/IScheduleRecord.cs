namespace OpenRailData.Schedule.NetworkRailScheduleParser.Records
{
    public interface IScheduleRecord : IIdentifyable
    {
        ScheduleRecordType RecordIdentity { get; set; }
    }
}
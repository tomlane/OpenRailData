namespace OpenRailData.Schedule.NetworkRailEntites.Records
{
    public interface IScheduleRecord : IIdentifyable
    {
        ScheduleRecordType RecordIdentity { get; set; }
    }
}
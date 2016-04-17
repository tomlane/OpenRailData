namespace OpenRailData.Domain.ScheduleRecords
{
    public interface IScheduleRecord 
    {
        ScheduleRecordType RecordIdentity { get; }
    }
}
namespace OpenRailData.Schedule.Entities
{
    public interface IScheduleRecord 
    {
        /// <summary>
        /// Schedule record type identity.
        /// </summary>
        ScheduleRecordType RecordIdentity { get; }
    }
}
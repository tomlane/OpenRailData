namespace OpenRailData.Domain.ScheduleRecords
{
    public interface IScheduleRecord 
    {
        /// <summary>
        /// Schedule record type identity.
        /// </summary>
        ScheduleRecordType RecordIdentity { get; }
    }
}
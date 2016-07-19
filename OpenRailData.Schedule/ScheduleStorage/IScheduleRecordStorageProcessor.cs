using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleStorage
{
    public interface IScheduleRecordStorageProcessor
    {
        ScheduleRecordType RecordKey { get; }

        void StoreRecord(IScheduleRecord record);
    }
}
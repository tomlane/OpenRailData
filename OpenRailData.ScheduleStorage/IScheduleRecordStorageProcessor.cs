using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleStorage
{
    public interface IScheduleRecordStorageProcessor
    {
        ScheduleRecordType RecordKey { get; }

        void StoreRecord(IScheduleRecord record);
    }
}
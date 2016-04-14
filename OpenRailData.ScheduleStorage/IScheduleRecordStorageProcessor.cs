using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.ScheduleStorage
{
    public interface IScheduleRecordStorageProcessor
    {
        ScheduleRecordType RecordKey { get; }

        void StoreRecord(IScheduleRecord record);
    }
}
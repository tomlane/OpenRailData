using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor
{
    public interface IScheduleRecordStorageProcessor
    {
        ScheduleRecordType RecordKey { get; }

        void StoreRecord(IScheduleRecord record);
    }
}
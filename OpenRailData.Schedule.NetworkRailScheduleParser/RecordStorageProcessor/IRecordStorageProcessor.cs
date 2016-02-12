using OpenRailData.Schedule.NetworkRailScheduleParser.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.RecordStorageProcessor
{
    public interface IRecordStorageProcessor
    {
        void StoreRecord(IScheduleRecord recordToStore);
    }
}
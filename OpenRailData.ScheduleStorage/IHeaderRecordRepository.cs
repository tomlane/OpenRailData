using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.ScheduleStorage
{
    public interface IHeaderRecordRepository
    {
        void InsertRecord(HeaderRecord record);

        HeaderRecord GetPreviousUpdate();
    }
}
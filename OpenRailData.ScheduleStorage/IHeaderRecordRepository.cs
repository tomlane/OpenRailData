using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleStorage
{
    public interface IHeaderRecordRepository
    {
        void InsertRecord(HeaderRecord record);

        HeaderRecord GetPreviousUpdate();
    }
}
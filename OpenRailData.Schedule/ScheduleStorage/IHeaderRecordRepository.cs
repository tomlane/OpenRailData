using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleStorage
{
    public interface IHeaderRecordRepository
    {
        void InsertRecord(HeaderRecord record);
        HeaderRecord GetPreviousUpdate();

        Task InsertRecordAsync(HeaderRecord record);
        Task<HeaderRecord> GetPreviousUpdateAsync();
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleStorage
{
    public interface IHeaderRecordRepository
    {
        Task InsertRecord(HeaderRecord record);
        Task<List<HeaderRecord>> GetPreviousUpdates();
    }
}
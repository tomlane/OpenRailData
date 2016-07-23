using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleStorage
{
    public interface ITiplocRecordRepository
    {
        Task InsertRecord(TiplocRecord record);
        Task InsertMultipleRecords(IEnumerable<TiplocRecord> records);
        Task AmendRecord(TiplocRecord record);
        Task DeleteRecord(TiplocRecord record);
        
        Task<List<TiplocRecord>> GetAllTiplocs();
        Task<List<TiplocRecord>> GetTiplocsByStanox(string stanox);
        Task<List<TiplocRecord>> GetTiplocsByCrs(string crs);
        Task<TiplocRecord> GetTiplocByTiplocCode(string tiplocCode);
    }
}
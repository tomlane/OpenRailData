using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleStorage
{
    public interface ITiplocRecordRepository
    {
        void InsertRecord(TiplocRecord record);
        void AmendRecord(TiplocRecord record);
        void DeleteRecord(TiplocRecord record);

        Task InsertRecordAsync(TiplocRecord record);
        Task InsertMultipleRecordsAsync(IEnumerable<TiplocRecord> records);
        Task AmendRecordAsync(TiplocRecord record);
        Task DeleteRecordAsync(TiplocRecord record);


        Task<List<TiplocRecord>> GetAllTiplocs();
        Task<List<TiplocRecord>> GetTiplocsByStanox(string stanox);
        Task<List<TiplocRecord>> GetTiplocsByCrs(string crs);
        Task<TiplocRecord> GetTiplocByTiplocCode(string tiplocCode);
    }
}
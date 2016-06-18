using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleStorage
{
    public interface ITiplocRecordRepository
    {
        void InsertRecord(TiplocRecord record);
        void AmendRecord(TiplocRecord record);
        void DeleteRecord(TiplocRecord record);
        void AmendLocationName(string locationName, string tiplocCode);

        Task InsertRecordAsync(TiplocRecord record);
        Task InsertMultipleRecordsAsync(IEnumerable<TiplocRecord> records);
        Task AmendRecordAsync(TiplocRecord record);
        Task DeleteRecordAsync(TiplocRecord record);

        Task AmendLocationNameAsync(string locationName, string tiplocCode);

        Task<List<TiplocRecord>> GetAllTiplocs();
        Task<List<TiplocRecord>> GetTiplocsByStanox(string stanox);
        Task<List<TiplocRecord>> GetTiplocsByCrs(string crs);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleStorage
{
    public interface IScheduleLocationRecordRepository
    {
        void InsertMultipleRecords(IEnumerable<ScheduleLocationRecord> records);
        void DeleteMultipleRecords(IEnumerable<ScheduleLocationRecord> records);

        Task InsertMultipleRecordsAsync(IEnumerable<ScheduleLocationRecord> records);
        Task DeleteMultipleRecordsAsync(IEnumerable<ScheduleLocationRecord> records);

        Task<List<ScheduleLocationRecord>> GetLocationsByTiploc(string tiploc);
    }
}
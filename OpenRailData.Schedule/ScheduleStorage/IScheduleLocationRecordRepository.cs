using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleStorage
{
    public interface IScheduleLocationRecordRepository
    {
        Task InsertMultipleRecords(IEnumerable<ScheduleLocationRecord> records);
        Task DeleteMultipleRecords(IEnumerable<ScheduleLocationRecord> records);

        Task<List<ScheduleLocationRecord>> GetLocationsByTiploc(string tiploc);
    }
}
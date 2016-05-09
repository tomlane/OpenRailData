using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Repository
{
    public class ScheduleLocationMongoDbRepository : IScheduleLocationRecordRepository
    {
        public void InsertMultipleRecords(IEnumerable<ScheduleLocationRecord> records)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteMultipleRecords(IEnumerable<ScheduleLocationRecord> records)
        {
            throw new System.NotImplementedException();
        }

        public Task InsertMultipleRecordsAsync(IEnumerable<ScheduleLocationRecord> records)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteMultipleRecordsAsync(IEnumerable<ScheduleLocationRecord> records)
        {
            throw new System.NotImplementedException();
        }
    }
}
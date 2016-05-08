using System.Collections.Generic;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Repository
{
    public class ScheduleLocationMongoDbRepository : IScheduleLocationRecordRepository
    {
        public void InsertRecords(IEnumerable<ScheduleLocationRecord> records)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteRecords(IEnumerable<ScheduleLocationRecord> records)
        {
            throw new System.NotImplementedException();
        }
    }
}
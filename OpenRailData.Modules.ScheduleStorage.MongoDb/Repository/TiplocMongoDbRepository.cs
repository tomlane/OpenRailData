using System;
using MongoDB.Driver;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Repository
{
    public class TiplocMongoDbRepository : ITiplocRecordRepository
    {
        private readonly IMongoDatabase _database;

        public TiplocMongoDbRepository(IMongoDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException(nameof(database));

            _database = database;
        }

        public void InsertRecord(TiplocRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            throw new NotImplementedException();
        }

        public void AmendRecord(TiplocRecord record)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecord(TiplocRecord record)
        {
            throw new NotImplementedException();
        }

        public void AmendLocationName(string locationName, string tiplocCode)
        {
            throw new NotImplementedException();
        }
    }
}
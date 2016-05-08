using System;
using MongoDB.Driver;
using OpenRailData.Modules.ScheduleStorage.MongoDb.Repository;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.UnitOfWork
{
    public class ScheduleUnitOfWork : IScheduleUnitOfWork
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        public IHeaderRecordRepository HeaderRecords { get; }
        public ITiplocRecordRepository TiplocRecords { get; }
        public IAssociationRecordRepository AssociationRecords { get; }
        public IScheduleRecordRepository ScheduleRecords { get; }
        public IScheduleLocationRecordRepository ScheduleLocationRecords { get; }
        
        public ScheduleUnitOfWork(IMongoDbClientFactory clientFactory)
        {
            if (clientFactory == null)
                throw new ArgumentNullException(nameof(clientFactory));

            _client = clientFactory.Create();
            _database = _client.GetDatabase("NetworkRailSchedule");

            TiplocRecords = new TiplocMongoDbRepository(_database);
        }

        public int Complete()
        {
            return 1;
        }

        public void Dispose() { }
    }
}
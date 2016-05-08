using System;
using MongoDB.Driver;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.MongoDb.Converters;
using OpenRailData.Modules.ScheduleStorage.MongoDb.Documents;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Repository
{
    public class HeaderMongoDbRepository : IHeaderRecordRepository
    {
        private readonly IMongoCollection<HeaderDocument> _collection;

        public HeaderMongoDbRepository(IMongoDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException(nameof(database));

            _collection = database.GetCollection<HeaderDocument>("Headers");
        }

        public void InsertRecord(HeaderRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var document = HeaderEntityGenerator.RecordToDocument(record);

            _collection.InsertOne(document);
        }

        public HeaderRecord GetPreviousUpdate()
        {
            var document = _collection.Find(x => x.DateOfExtract < DateTime.Now).First();

            var record = HeaderEntityGenerator.DocumentToRecord(document);

            return record;
        }
    }
}
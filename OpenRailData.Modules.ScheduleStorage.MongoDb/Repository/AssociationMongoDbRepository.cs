using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.MongoDb.Converters;
using OpenRailData.Modules.ScheduleStorage.MongoDb.Documents;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.MongoDb.Repository
{
    public class AssociationMongoDbRepository : IAssociationRecordRepository
    {
        private readonly IMongoCollection<AssociationDocument> _collection;

        public AssociationMongoDbRepository(IMongoDatabase database)
        {
            if (database == null)
                throw new ArgumentNullException(nameof(database));

            _collection = database.GetCollection<AssociationDocument>("Associations");
        }

        public void InsertRecord(AssociationRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var document = AssociationEntityGenerator.RecordToDocument(record);

            _collection.InsertOne(document);
        }

        public void AmendRecord(AssociationRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var document = AssociationEntityGenerator.RecordToDocument(record);

            _collection.UpdateOne(x =>
                x.MainTrainUid == record.MainTrainUid &&
                x.AssocTrainUid == record.AssocTrainUid &&
                x.DateFrom == record.StartDate &&
                x.StpIndicator == record.StpIndicator,
                new ObjectUpdateDefinition<AssociationDocument>(document));
        }

        public void DeleteRecord(AssociationRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            _collection.DeleteOne(x =>
                x.MainTrainUid == record.MainTrainUid &&
                x.AssocTrainUid == record.AssocTrainUid &&
                x.DateFrom == record.StartDate &&
                x.StpIndicator == record.StpIndicator);
        }

        public async Task InsertRecordAsync(AssociationRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var document = AssociationEntityGenerator.RecordToDocument(record);

            await _collection.InsertOneAsync(document, null, CancellationToken.None);
        }

        public async Task InsertMultipleRecordsAsync(IEnumerable<AssociationRecord> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            var documents = records.Select(AssociationEntityGenerator.RecordToDocument).ToList();

            await _collection.InsertManyAsync(documents);
        }

        public async Task AmendRecordAsync(AssociationRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var document = AssociationEntityGenerator.RecordToDocument(record);

            await _collection.UpdateOneAsync(x =>
                x.MainTrainUid == record.MainTrainUid &&
                x.AssocTrainUid == record.AssocTrainUid &&
                x.DateFrom == record.StartDate &&
                x.StpIndicator == record.StpIndicator,
                new ObjectUpdateDefinition<AssociationDocument>(document));
        }

        public async Task DeleteRecordAsync(AssociationRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            await _collection.DeleteOneAsync(x =>
                x.MainTrainUid == record.MainTrainUid &&
                x.AssocTrainUid == record.AssocTrainUid &&
                x.DateFrom == record.StartDate &&
                x.StpIndicator == record.StpIndicator);
        }
    }
}
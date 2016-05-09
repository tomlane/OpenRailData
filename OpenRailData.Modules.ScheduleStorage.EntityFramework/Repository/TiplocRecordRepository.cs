using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Logging;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Converters;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Repository
{
    public class TiplocRecordRepository : BaseRepository<TiplocRecordEntity>, ITiplocRecordRepository 
    {
        private readonly ILog Logger = LogManager.GetLogger("Repository.TiplocRecordEntity");

        public TiplocRecordRepository(IScheduleContext context) : base(context)
        {
        }

        public void InsertRecord(TiplocRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            if (Logger.IsTraceEnabled)
                Logger.Trace($"Inserting new Tiploc record: {record}");

            var entity = TiplocEntityGenerator.RecordToEntity(record);

            Add(entity);
        }

        public void AmendRecord(TiplocRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var currentRecord = Find(x => x.TiplocCode == record.TiplocCode).FirstOrDefault();

            if (currentRecord == null)
            {
                if (Logger.IsWarnEnabled)
                    Logger.Warn($"Failed to find Tiploc record to amend. Criteria: {record}");
            }
            else
            {
                if (Logger.IsTraceEnabled)
                    Logger.Trace($"Amending Tiploc record: {currentRecord}. New record: {record}");

                var entity = TiplocEntityGenerator.RecordToEntity(record);

                currentRecord = entity;

                Add(currentRecord);
            }
        }

        public void DeleteRecord(TiplocRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var recordToDelete = Find(x => x.TiplocCode == record.TiplocCode).FirstOrDefault();

            if (recordToDelete == null)
            {
                if (Logger.IsWarnEnabled)
                    Logger.Warn($"Failed to find Tiploc record to delete. Criteria: {record}");
            }
            else
            {
                if (Logger.IsTraceEnabled)
                    Logger.Trace($"Deleting Tiploc record: {recordToDelete}. Criteria: {record}");

                Remove(recordToDelete);
            }
        }

        public void AmendLocationName(string locationName, string tiplocCode)
        {
            if (string.IsNullOrWhiteSpace(locationName))
                throw new ArgumentNullException(nameof(locationName));

            if (string.IsNullOrWhiteSpace(tiplocCode))
                throw new ArgumentNullException(nameof(tiplocCode));

            var recordToAmend = Find(x => x.TiplocCode == tiplocCode).FirstOrDefault();

            if (recordToAmend == null)
            {
                if (Logger.IsWarnEnabled)
                    Logger.Warn($"Could not find Tiploc record to amend. Criteria: {tiplocCode}");

                return;
            }

            recordToAmend.LocationName = locationName;

            Add(recordToAmend);
        }

        public Task InsertRecordAsync(TiplocRecord record)
        {
            throw new NotImplementedException();
        }

        public Task InsertMultipleRecordsAsync(IEnumerable<TiplocRecord> records)
        {
            throw new NotImplementedException();
        }

        public Task AmendRecordAsync(TiplocRecord record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecordAsync(TiplocRecord record)
        {
            throw new NotImplementedException();
        }

        public Task AmendLocationNameAsync(string locationName, string tiplocCode)
        {
            throw new NotImplementedException();
        }
    }
}
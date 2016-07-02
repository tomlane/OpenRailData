﻿using System;
using System.Threading.Tasks;
using OpenRailData.CommonDatabase;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.ScheduleStorage.EntityFramework.Converters;
using OpenRailData.ScheduleStorage.EntityFramework.Entities;
using System.Linq;

namespace OpenRailData.ScheduleStorage.EntityFramework.Repository
{
    public class HeaderRecordRepository : BaseRepository<HeaderRecordEntity>, IHeaderRecordRepository
    {
        public HeaderRecordRepository(IScheduleContext context) : base(context)
        {
        }

        public void InsertRecord(HeaderRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var recordEntity = HeaderEntityGenerator.RecordToEntity(record);

            Add(recordEntity);
        }

        public HeaderRecord GetPreviousUpdate()
        {
            var update = Find(x => true)
                .OrderByDescending(x => x.DateOfExtract)
                .Take(1).FirstOrDefault();

            var record = HeaderEntityGenerator.EntityToRecord(update);

            return record;
        }

        public Task InsertRecordAsync(HeaderRecord record)
        {
            throw new NotImplementedException();
        }

        public Task<HeaderRecord> GetPreviousUpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.ScheduleStorage.EntityFramework.Converters;
using OpenRailData.ScheduleStorage.EntityFramework.Entities;
using System.Linq;
using OpenRailData.Schedule.Entities;
using OpenRailData.Schedule.ScheduleStorage;

namespace OpenRailData.ScheduleStorage.EntityFramework.Repository
{
    public class HeaderRecordRepository : IHeaderRecordRepository
    {
        private readonly IScheduleContext _context;

        public HeaderRecordRepository(IScheduleContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public Task InsertRecord(HeaderRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = HeaderEntityGenerator.RecordToEntity(record);

            _context.GetSet<HeaderRecordEntity>().Add(entity);

            return Task.CompletedTask;
        }

        public Task<List<HeaderRecord>> GetPreviousUpdates()
        {
            var updates = _context.GetSet<HeaderRecordEntity>().OrderByDescending(x => x.DateOfExtract);

            return Task.FromResult(updates.Select(HeaderEntityGenerator.EntityToRecord).ToList());
        }
    }
}
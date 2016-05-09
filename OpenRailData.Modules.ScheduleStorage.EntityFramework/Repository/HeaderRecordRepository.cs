using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Logging;
using OpenRailData.Domain.ScheduleRecords;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Converters;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;
using OpenRailData.ScheduleStorage;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework.Repository
{
    public class HeaderRecordRepository : BaseRepository<HeaderRecordEntity>, IHeaderRecordRepository
    {
        private readonly ILog Logger = LogManager.GetLogger("Repository.HeaderRecordEntity");

        public HeaderRecordRepository(IScheduleContext context) : base(context)
        {
        }

        public void InsertRecord(HeaderRecord record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            if (Logger.IsTraceEnabled)
                Logger.Trace($"Inserting new Header record: {record}");

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
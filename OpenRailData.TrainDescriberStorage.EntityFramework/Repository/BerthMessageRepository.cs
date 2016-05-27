using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OpenRailData.Domain.TrainDescriber;
using OpenRailData.Schedule.CommonDatabase;
using OpenRailData.TrainDescriberStorage.EntityFramework.Entities;
using OpenRailData.TrainDescriberStorage.EntityFramework.Mappers;

namespace OpenRailData.TrainDescriberStorage.EntityFramework.Repository
{
    public class BerthMessageRepository : BaseRepository<BerthMessageEntity>, IBerthMessageRepository
    {
        private readonly IMapper _mapper;

        public BerthMessageRepository(IContext context) : base(context)
        {
            _mapper = TrainDescriberMapperConfiguration.CreateMapper();
        }

        public void InsertRecord(BerthMessage record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<BerthMessageEntity>(record);

            Add(entity);
        }

        public void AmendRecord(BerthMessage record)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecord(BerthMessage record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<BerthMessageEntity>(record);

            Remove(entity);
        }

        public Task InsertRecordAsync(BerthMessage record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<BerthMessageEntity>(record);

            Add(entity);

            return Task.CompletedTask;
        }

        public Task InsertMultipleRecordsAsync(IEnumerable<BerthMessage> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            var entites = records.Select(_mapper.Map<BerthMessageEntity>).ToList();

            AddRange(entites);

            return Task.CompletedTask;
        }

        public Task AmendRecordAsync(BerthMessage record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecordAsync(BerthMessage record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<BerthMessageEntity>(record);

            Remove(entity);

            return Task.CompletedTask;
        }
    }
}
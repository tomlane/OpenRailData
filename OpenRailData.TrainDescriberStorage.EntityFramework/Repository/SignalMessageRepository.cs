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
    public class SignalMessageRepository : BaseRepository<SignalMessageEntity>, ISignalMessageRepository
    {
        private readonly IMapper _mapper;

        public SignalMessageRepository(ITrainDescriberContext context) : base(context)
        {
            _mapper = TrainDescriberMapperConfiguration.CreateMapper();
        }

        public void InsertRecord(SignalMessage record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<SignalMessageEntity>(record);

            Add(entity);
        }

        public void AmendRecord(SignalMessage record)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecord(SignalMessage record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<SignalMessageEntity>(record);

            Remove(entity);
        }

        public Task InsertRecordAsync(SignalMessage record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<SignalMessageEntity>(record);

            Add(entity);

            return Task.CompletedTask;
        }

        public Task InsertMultipleRecordsAsync(IEnumerable<SignalMessage> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            var entities = records.Select(_mapper.Map<SignalMessageEntity>).ToList();

            AddRange(entities);

            return Task.CompletedTask;
        }

        public Task AmendRecordAsync(SignalMessage record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecordAsync(SignalMessage record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<SignalMessageEntity>(record);

            Remove(entity);

            return Task.CompletedTask;
        }
    }
}
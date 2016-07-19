using System;
using System.Threading.Tasks;
using AutoMapper;
using OpenRailData.CommonDatabase;
using OpenRailData.TrainDescriber.Entities;
using OpenRailData.TrainDescriber.TrainDescriberStorage;
using OpenRailData.TrainDescriberStorage.EntityFramework.Entities;
using OpenRailData.TrainDescriberStorage.EntityFramework.Mappers;

namespace OpenRailData.TrainDescriberStorage.EntityFramework.Repository
{
    public class SignalMessageRepository : BaseRepository<SignalMessageEntity>, ITrainDescriberRepository<SignalMessage>
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
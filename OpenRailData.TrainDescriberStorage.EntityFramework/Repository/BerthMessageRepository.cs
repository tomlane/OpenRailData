using System;
using System.Threading.Tasks;
using AutoMapper;
using OpenRailData.CommonDatabase;
using OpenRailData.Domain.TrainDescriber;
using OpenRailData.TrainDescriberStorage.EntityFramework.Entities;
using OpenRailData.TrainDescriberStorage.EntityFramework.Mappers;

namespace OpenRailData.TrainDescriberStorage.EntityFramework.Repository
{
    public class BerthMessageRepository : BaseRepository<BerthMessageEntity>, ITrainDescriberRepository<BerthMessage>
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
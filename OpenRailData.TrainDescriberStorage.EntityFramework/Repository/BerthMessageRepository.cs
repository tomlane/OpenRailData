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
    public class BerthMessageRepository : ITrainDescriberRepository<BerthMessage>
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public BerthMessageRepository(IContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
            _mapper = TrainDescriberMapperConfiguration.CreateMapper();
        }
        
        public Task InsertRecord(BerthMessage record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<BerthMessageEntity>(record);

            _context.GetSet<BerthMessageEntity>().Add(entity);

            return Task.CompletedTask;
        }

        public Task AmendRecord(BerthMessage record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecord(BerthMessage record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<BerthMessageEntity>(record);

            _context.GetSet<BerthMessageEntity>().Remove(entity);

            return Task.CompletedTask;
        }
    }
}
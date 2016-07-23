using System;
using System.Threading.Tasks;
using AutoMapper;
using OpenRailData.TrainDescriber.Entities;
using OpenRailData.TrainDescriber.TrainDescriberStorage;
using OpenRailData.TrainDescriberStorage.EntityFramework.Entities;
using OpenRailData.TrainDescriberStorage.EntityFramework.Mappers;

namespace OpenRailData.TrainDescriberStorage.EntityFramework.Repository
{
    public class SignalMessageRepository : ITrainDescriberRepository<SignalMessage>
    {
        private readonly ITrainDescriberContext _context;
        private readonly IMapper _mapper;

        public SignalMessageRepository(ITrainDescriberContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
            _mapper = TrainDescriberMapperConfiguration.CreateMapper();
        }
        
        public Task InsertRecord(SignalMessage record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<SignalMessageEntity>(record);

            _context.GetSet<SignalMessageEntity>().Add(entity);

            return Task.CompletedTask;
        }

        public Task AmendRecord(SignalMessage record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecord(SignalMessage record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<SignalMessageEntity>(record);

            _context.GetSet<SignalMessageEntity>().Remove(entity);

            return Task.CompletedTask;
        }
    }
}
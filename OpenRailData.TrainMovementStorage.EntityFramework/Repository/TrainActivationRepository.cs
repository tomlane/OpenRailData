using System;
using System.Threading.Tasks;
using AutoMapper;
using OpenRailData.TrainMovement.Entities;
using OpenRailData.TrainMovement.TrainMovementStorage;
using OpenRailData.TrainMovementStorage.EntityFramework.Entities;
using OpenRailData.TrainMovementStorage.EntityFramework.Mappers;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Repository
{
    public class TrainActivationRepository : ITrainMovementRepository<TrainActivation>
    {
        private readonly ITrainMovementContext _context;
        private readonly IMapper _mapper;

        public TrainActivationRepository(ITrainMovementContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
            _mapper = TrainMovementMapperConfiguration.CreateMapper();
        }

        public Task InsertRecord(TrainActivation record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainActivationEntity>(record);

            _context.GetSet<TrainActivationEntity>().Add(entity);

            return Task.CompletedTask;
        }

        public Task AmendRecord(TrainActivation record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecord(TrainActivation record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainActivationEntity>(record);

            _context.GetSet<TrainActivationEntity>().Remove(entity);

            return Task.CompletedTask;
        }
    }
}
using System;
using System.Threading.Tasks;
using AutoMapper;
using OpenRailData.TrainMovement.TrainMovementStorage;
using OpenRailData.TrainMovementStorage.EntityFramework.Entities;
using OpenRailData.TrainMovementStorage.EntityFramework.Mappers;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Repository
{
    public class TrainMovementRepository :ITrainMovementRepository<TrainMovement.Entities.TrainMovement>
    {
        private readonly ITrainMovementContext _context;
        private readonly IMapper _mapper;

        public TrainMovementRepository(ITrainMovementContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
            _mapper = TrainMovementMapperConfiguration.CreateMapper();
        }

        public Task InsertRecord(TrainMovement.Entities.TrainMovement record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainMovementEntity>(record);

            _context.GetSet<TrainMovementEntity>().Add(entity);

            return Task.CompletedTask;
        }

        public Task AmendRecord(TrainMovement.Entities.TrainMovement record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecord(TrainMovement.Entities.TrainMovement record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainMovementEntity>(record);

            _context.GetSet<TrainMovementEntity>().Remove(entity);

            return Task.CompletedTask;
        }
    }
}
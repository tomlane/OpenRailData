using System;
using System.Threading.Tasks;
using AutoMapper;
using OpenRailData.TrainMovement.Entities;
using OpenRailData.TrainMovement.TrainMovementStorage;
using OpenRailData.TrainMovementStorage.EntityFramework.Entities;
using OpenRailData.TrainMovementStorage.EntityFramework.Mappers;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Repository
{
    public class TrainCancellationRepository : ITrainMovementRepository<TrainCancellation>
    {
        private readonly ITrainMovementContext _context;
        private readonly IMapper _mapper;

        public TrainCancellationRepository(ITrainMovementContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
            _mapper = TrainMovementMapperConfiguration.CreateMapper();
        }

        public Task InsertRecord(TrainCancellation record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainCancellationEntity>(record);

            _context.GetSet<TrainCancellationEntity>().Add(entity);

            return Task.CompletedTask;
        }

        public Task AmendRecord(TrainCancellation record)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteRecord(TrainCancellation record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainCancellationEntity>(record);

            _context.GetSet<TrainCancellationEntity>().Remove(entity);

            return Task.CompletedTask;
        }
    }
}
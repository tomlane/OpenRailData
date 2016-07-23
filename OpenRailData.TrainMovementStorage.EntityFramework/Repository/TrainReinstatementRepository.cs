using System;
using System.Threading.Tasks;
using AutoMapper;
using OpenRailData.TrainMovement.Entities;
using OpenRailData.TrainMovement.TrainMovementStorage;
using OpenRailData.TrainMovementStorage.EntityFramework.Entities;
using OpenRailData.TrainMovementStorage.EntityFramework.Mappers;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Repository
{
    public class TrainReinstatementRepository : ITrainMovementRepository<TrainReinstatement>
    {
        private readonly ITrainMovementContext _context;
        private readonly IMapper _mapper;

        public TrainReinstatementRepository(ITrainMovementContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
            _mapper = TrainMovementMapperConfiguration.CreateMapper();
        }

        public Task InsertRecord(TrainReinstatement record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainReinstatementEntity>(record);

            _context.GetSet<TrainReinstatementEntity>().Add(entity);

            return Task.CompletedTask;
        }

        public Task AmendRecord(TrainReinstatement record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecord(TrainReinstatement record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainReinstatementEntity>(record);

            _context.GetSet<TrainReinstatementEntity>().Remove(entity);

            return Task.CompletedTask;
        }
    }
}
using System;
using System.Threading.Tasks;
using AutoMapper;
using OpenRailData.CommonDatabase;
using OpenRailData.TrainMovement.TrainMovementStorage;
using OpenRailData.TrainMovementStorage.EntityFramework.Entities;
using OpenRailData.TrainMovementStorage.EntityFramework.Mappers;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Repository
{
    public class TrainMovementRepository : BaseRepository<TrainMovementEntity>, ITrainMovementRepository<TrainMovement.Entities.TrainMovement>
    {
        private readonly IMapper _mapper;

        public TrainMovementRepository(ITrainMovementContext context) : base(context)
        {
            _mapper = TrainMovementMapperConfiguration.CreateMapper();
        }

        public void InsertRecord(TrainMovement.Entities.TrainMovement record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainMovementEntity>(record);

            Add(entity);
        }

        public void AmendRecord(TrainMovement.Entities.TrainMovement record)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecord(TrainMovement.Entities.TrainMovement record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainMovementEntity>(record);

            Remove(entity);
        }

        public Task InsertRecordAsync(TrainMovement.Entities.TrainMovement record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainMovementEntity>(record);

            Add(entity);

            return Task.CompletedTask;
        }

        public Task AmendRecordAsync(TrainMovement.Entities.TrainMovement record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecordAsync(TrainMovement.Entities.TrainMovement record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainMovementEntity>(record);

            Remove(entity);

            return Task.CompletedTask;
        }
    }
}
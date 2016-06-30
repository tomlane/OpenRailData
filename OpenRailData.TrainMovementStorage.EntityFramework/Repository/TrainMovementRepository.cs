using System;
using System.Threading.Tasks;
using AutoMapper;
using OpenRailData.CommonDatabase;
using OpenRailData.Domain.TrainMovements;
using OpenRailData.TrainMovementStorage.EntityFramework.Entities;
using OpenRailData.TrainMovementStorage.EntityFramework.Mappers;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Repository
{
    public class TrainMovementRepository : BaseRepository<TrainMovementEntity>, ITrainMovementRepository<TrainMovement>
    {
        private readonly IMapper _mapper;

        public TrainMovementRepository(ITrainMovementContext context) : base(context)
        {
            _mapper = TrainMovementMapperConfiguration.CreateMapper();
        }

        public void InsertRecord(TrainMovement record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainMovementEntity>(record);

            Add(entity);
        }

        public void AmendRecord(TrainMovement record)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecord(TrainMovement record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainMovementEntity>(record);

            Remove(entity);
        }

        public Task InsertRecordAsync(TrainMovement record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainMovementEntity>(record);

            Add(entity);

            return Task.CompletedTask;
        }

        public Task AmendRecordAsync(TrainMovement record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecordAsync(TrainMovement record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainMovementEntity>(record);

            Remove(entity);

            return Task.CompletedTask;
        }
    }
}
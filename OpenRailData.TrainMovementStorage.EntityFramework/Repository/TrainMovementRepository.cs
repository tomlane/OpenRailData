using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OpenRailData.Domain.TrainMovements;
using OpenRailData.Schedule.CommonDatabase;
using OpenRailData.TrainMovementStorage.EntityFramework.Entites;
using OpenRailData.TrainMovementStorage.EntityFramework.Mappers;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Repository
{
    public class TrainMovementRepository : BaseRepository<TrainMovementEntity>, ITrainMovementRepository
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

        public Task InsertMultipleRecordsAsync(IEnumerable<TrainMovement> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            var entites = records.Select(_mapper.Map<TrainMovementEntity>).ToList();

            RemoveRange(entites);

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
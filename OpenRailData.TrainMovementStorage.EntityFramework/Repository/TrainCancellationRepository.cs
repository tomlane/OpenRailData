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
    public class TrainCancellationRepository : BaseRepository<TrainCancellationEntity>, ITrainCancellationRepository
    {
        private readonly IMapper _mapper;

        public TrainCancellationRepository(ITrainMovementContext context) : base(context)
        {
            _mapper = TrainMovementMapperConfiguration.CreateMapper();
        }

        public void InsertRecord(TrainCancellation record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainCancellationEntity>(record);

            Add(entity);
        }

        public void AmendRecord(TrainCancellation record)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteRecord(TrainCancellation record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainCancellationEntity>(record);

            Remove(entity);
        }

        public Task InsertRecordAsync(TrainCancellation record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainCancellationEntity>(record);

            Add(entity);

            return Task.CompletedTask;
        }

        public Task InsertMultipleRecordsAsync(IEnumerable<TrainCancellation> records)
        {
            if (records == null)
                throw new ArgumentNullException(nameof(records));

            var entites = records.Select(_mapper.Map<TrainCancellationEntity>).ToList();

            RemoveRange(entites);

            return Task.CompletedTask;
        }

        public Task AmendRecordAsync(TrainCancellation record)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteRecordAsync(TrainCancellation record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainCancellationEntity>(record);

            Remove(entity);

            return Task.CompletedTask;
        }
    }
}
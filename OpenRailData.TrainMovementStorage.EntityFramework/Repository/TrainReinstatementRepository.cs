using System;
using System.Threading.Tasks;
using AutoMapper;
using OpenRailData.Domain.TrainMovements;
using OpenRailData.Schedule.CommonDatabase;
using OpenRailData.TrainMovementStorage.EntityFramework.Entites;
using OpenRailData.TrainMovementStorage.EntityFramework.Mappers;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Repository
{
    public class TrainReinstatementRepository : BaseRepository<TrainReinstatementEntity>, ITrainMovementRepository<TrainReinstatement>
    {
        private readonly IMapper _mapper;

        public TrainReinstatementRepository(ITrainMovementContext context) : base(context)
        {
            _mapper = TrainMovementMapperConfiguration.CreateMapper();
        }

        public void InsertRecord(TrainReinstatement record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainReinstatementEntity>(record);

            Add(entity);
        }

        public void AmendRecord(TrainReinstatement record)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecord(TrainReinstatement record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainReinstatementEntity>(record);

            Remove(entity);
        }

        public Task InsertRecordAsync(TrainReinstatement record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainReinstatementEntity>(record);

            Add(entity);

            return Task.CompletedTask;
        }

        public Task AmendRecordAsync(TrainReinstatement record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecordAsync(TrainReinstatement record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainReinstatementEntity>(record);

            Remove(entity);

            return Task.CompletedTask;
        }
    }
}
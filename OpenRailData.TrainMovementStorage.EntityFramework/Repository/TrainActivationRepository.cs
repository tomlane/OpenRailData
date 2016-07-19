using System;
using System.Threading.Tasks;
using AutoMapper;
using OpenRailData.CommonDatabase;
using OpenRailData.TrainMovement.Entities;
using OpenRailData.TrainMovement.TrainMovementStorage;
using OpenRailData.TrainMovementStorage.EntityFramework.Entities;
using OpenRailData.TrainMovementStorage.EntityFramework.Mappers;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Repository
{
    public class TrainActivationRepository : BaseRepository<TrainActivationEntity>, ITrainMovementRepository<TrainActivation>
    {
        private readonly IMapper _mapper;

        public TrainActivationRepository(ITrainMovementContext context) : base(context)
        {
            _mapper = TrainMovementMapperConfiguration.CreateMapper();
        }

        public void InsertRecord(TrainActivation record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainActivationEntity>(record);

            Add(entity);
        }

        public void AmendRecord(TrainActivation record)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecord(TrainActivation record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainActivationEntity>(record);

            Remove(entity);
        }

        public Task InsertRecordAsync(TrainActivation record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainActivationEntity>(record);

            Add(entity);

            return Task.CompletedTask;
        }

        public Task AmendRecordAsync(TrainActivation record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecordAsync(TrainActivation record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<TrainActivationEntity>(record);

            Remove(entity);

            return Task.CompletedTask;
        }
    }
}
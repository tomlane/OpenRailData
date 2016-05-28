using System;
using System.Threading.Tasks;
using AutoMapper;
using OpenRailData.Domain.TrainMovements;
using OpenRailData.Schedule.CommonDatabase;
using OpenRailData.TrainMovementStorage.EntityFramework.Entites;
using OpenRailData.TrainMovementStorage.EntityFramework.Mappers;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Repository
{
    public class ChangeOfOriginRepository : BaseRepository<ChangeOfOriginEntity>, ITrainMovementRepository<ChangeOfOrigin>
    {
        private readonly IMapper _mapper;

        public ChangeOfOriginRepository(IContext context) : base(context)
        {
            _mapper = TrainMovementMapperConfiguration.CreateMapper();
        }

        public void InsertRecord(ChangeOfOrigin record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<ChangeOfOriginEntity>(record);

            Add(entity);
        }

        public void AmendRecord(ChangeOfOrigin record)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecord(ChangeOfOrigin record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<ChangeOfOriginEntity>(record);

            Remove(entity);
        }

        public Task InsertRecordAsync(ChangeOfOrigin record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<ChangeOfOriginEntity>(record);

            Add(entity);

            return Task.CompletedTask;
        }

        public Task AmendRecordAsync(ChangeOfOrigin record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecordAsync(ChangeOfOrigin record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<ChangeOfOriginEntity>(record);

            Remove(entity);

            return Task.CompletedTask;
        }
    }
}
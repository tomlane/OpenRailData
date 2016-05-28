using System;
using System.Threading.Tasks;
using AutoMapper;
using OpenRailData.Domain.TrainMovements;
using OpenRailData.Schedule.CommonDatabase;
using OpenRailData.TrainMovementStorage.EntityFramework.Entites;
using OpenRailData.TrainMovementStorage.EntityFramework.Mappers;

namespace OpenRailData.TrainMovementStorage.EntityFramework.Repository
{
    public class ChangeOfIdentityRepository : BaseRepository<ChangeOfIdentityEntity>, ITrainMovementRepository<ChangeOfIdentity>
    {
        private readonly IMapper _mapper;

        public ChangeOfIdentityRepository(IContext context) : base(context)
        {
            _mapper = TrainMovementMapperConfiguration.CreateMapper();
        }

        public void InsertRecord(ChangeOfIdentity record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<ChangeOfIdentityEntity>(record);

            Add(entity);
        }

        public void AmendRecord(ChangeOfIdentity record)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecord(ChangeOfIdentity record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<ChangeOfIdentityEntity>(record);

            Remove(entity);
        }

        public Task InsertRecordAsync(ChangeOfIdentity record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<ChangeOfIdentityEntity>(record);

            Add(entity);

            return Task.CompletedTask;
        }

        public Task AmendRecordAsync(ChangeOfIdentity record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecordAsync(ChangeOfIdentity record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<ChangeOfIdentityEntity>(record);

            Remove(entity);

            return Task.CompletedTask;
        }
    }
}
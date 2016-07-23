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
    public class ChangeOfIdentityRepository : ITrainMovementRepository<ChangeOfIdentity>
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public ChangeOfIdentityRepository(IContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
            _mapper = TrainMovementMapperConfiguration.CreateMapper();
        }

        public Task InsertRecord(ChangeOfIdentity record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<ChangeOfIdentityEntity>(record);

            _context.GetSet<ChangeOfIdentityEntity>().Add(entity);

            return Task.CompletedTask;
        }

        public Task AmendRecord(ChangeOfIdentity record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecord(ChangeOfIdentity record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<ChangeOfIdentityEntity>(record);

            _context.GetSet<ChangeOfIdentityEntity>().Add(entity);

            return Task.CompletedTask;
        }
    }
}
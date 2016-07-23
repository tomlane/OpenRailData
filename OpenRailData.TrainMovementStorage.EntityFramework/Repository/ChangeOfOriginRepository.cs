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
    public class ChangeOfOriginRepository : ITrainMovementRepository<ChangeOfOrigin>
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public ChangeOfOriginRepository(IContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
            _mapper = TrainMovementMapperConfiguration.CreateMapper();
        }

        public Task InsertRecord(ChangeOfOrigin record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<ChangeOfOriginEntity>(record);

            _context.GetSet<ChangeOfOriginEntity>().Add(entity);

            return Task.CompletedTask;
        }

        public Task AmendRecord(ChangeOfOrigin record)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRecord(ChangeOfOrigin record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var entity = _mapper.Map<ChangeOfOriginEntity>(record);

            _context.GetSet<ChangeOfOriginEntity>().Remove(entity);

            return Task.CompletedTask;
        }
    }
}
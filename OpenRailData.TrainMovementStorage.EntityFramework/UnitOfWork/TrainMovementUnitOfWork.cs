using System;
using OpenRailData.TrainMovement.Entities;
using OpenRailData.TrainMovement.TrainMovementStorage;
using OpenRailData.TrainMovementStorage.EntityFramework.Repository;

namespace OpenRailData.TrainMovementStorage.EntityFramework.UnitOfWork
{
    public class TrainMovementUnitOfWork : ITrainMovementUnitOfWork
    {
        private readonly ITrainMovementContext _context;

        public TrainMovementUnitOfWork(ITrainMovementContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            _context = context;

            TrainActivations = new TrainActivationRepository(_context);
            TrainCancellations = new TrainCancellationRepository(_context);
            TrainMovements = new TrainMovementRepository(_context);
            TrainReinstatements = new TrainReinstatementRepository(_context);
            ChangeOfOrigins = new ChangeOfOriginRepository(_context);
            ChangeOfIdentities = new ChangeOfIdentityRepository(_context);
        }

        public void Dispose() => _context?.Dispose();

        public ITrainMovementRepository<TrainActivation> TrainActivations { get; }
        public ITrainMovementRepository<TrainCancellation> TrainCancellations { get; }
        public ITrainMovementRepository<TrainMovement.Entities.TrainMovement> TrainMovements { get; }
        public ITrainMovementRepository<TrainReinstatement> TrainReinstatements { get; }
        public ITrainMovementRepository<ChangeOfOrigin> ChangeOfOrigins { get; }
        public ITrainMovementRepository<ChangeOfIdentity> ChangeOfIdentities { get; }

        public int Complete() => _context.SaveChanges();
    }
}
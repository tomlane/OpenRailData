using System;
using OpenRailData.TrainMovementStorage.EntityFramework.Repository;

namespace OpenRailData.TrainMovementStorage.EntityFramework.UnitOfWork
{
    public class TrainMovementsUnitOfWork : ITrainMovementsUnitOfWork
    {
        private readonly ITrainMovementContext _context;

        public TrainMovementsUnitOfWork(ITrainMovementContext context)
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

        public ITrainActivationRepository TrainActivations { get; }
        public ITrainCancellationRepository TrainCancellations { get; }
        public ITrainMovementRepository TrainMovements { get; }
        public ITrainReinstatementRepository TrainReinstatements { get; }
        public IChangeOfOriginRepository ChangeOfOrigins { get; }
        public IChangeOfIdentityRepository ChangeOfIdentities { get; }

        public int Complete() => _context.SaveChanges();
    }
}
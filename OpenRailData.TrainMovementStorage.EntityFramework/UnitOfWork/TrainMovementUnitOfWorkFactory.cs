using System;
using OpenRailData.TrainMovement.TrainMovementStorage;

namespace OpenRailData.TrainMovementStorage.EntityFramework.UnitOfWork
{
    public class TrainMovementUnitOfWorkFactory : ITrainMovementUnitOfWorkFactory
    {
        private readonly ITrainMovementContextFactory _contextFactory;

        public TrainMovementUnitOfWorkFactory(ITrainMovementContextFactory contextFactory)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));

            _contextFactory = contextFactory;
        }

        public ITrainMovementUnitOfWork Create()
        {
            return new TrainMovementUnitOfWork(_contextFactory.Create());
        }
    }
}
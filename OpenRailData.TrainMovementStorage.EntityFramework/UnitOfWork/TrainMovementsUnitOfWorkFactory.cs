using System;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace OpenRailData.TrainMovementStorage.EntityFramework.UnitOfWork
{
    public class TrainMovementsUnitOfWorkFactory : ITrainMovementsUnitOfWorkFactory
    {
        private readonly IDbContextFactory<TrainMovementContext> _contextFactory;

        public TrainMovementsUnitOfWorkFactory(IDbContextFactory<TrainMovementContext> contextFactory)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));

            _contextFactory = contextFactory;
        }

        public ITrainMovementsUnitOfWork Create()
        {
            return new TrainMovementsUnitOfWork(_contextFactory.Create());
        }
    }
}
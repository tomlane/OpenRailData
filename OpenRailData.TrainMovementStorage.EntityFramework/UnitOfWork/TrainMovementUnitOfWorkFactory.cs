using System;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace OpenRailData.TrainMovementStorage.EntityFramework.UnitOfWork
{
    public class TrainMovementUnitOfWorkFactory : ITrainMovementUnitOfWorkFactory
    {
        private readonly IDbContextFactory<TrainMovementContext> _contextFactory;

        public TrainMovementUnitOfWorkFactory(IDbContextFactory<TrainMovementContext> contextFactory)
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
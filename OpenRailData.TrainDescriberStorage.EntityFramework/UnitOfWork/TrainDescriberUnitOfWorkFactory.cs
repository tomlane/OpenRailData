using System;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace OpenRailData.TrainDescriberStorage.EntityFramework.UnitOfWork
{
    public class TrainDescriberUnitOfWorkFactory : ITrainDescriberUnitOfWorkFactory
    {
        private readonly IDbContextFactory<TrainDescriberContext> _contextFactory;

        public TrainDescriberUnitOfWorkFactory(IDbContextFactory<TrainDescriberContext> contextFactory)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));

            _contextFactory = contextFactory;
        }

        public ITrainDescriberUnitOfWork Create()
        {
            return new TrainDescriberUnitOfWork(_contextFactory.Create());
        }
    }
}
using System;
using OpenRailData.TrainDescriber.TrainDescriberStorage;

namespace OpenRailData.TrainDescriberStorage.EntityFramework.UnitOfWork
{
    public class TrainDescriberUnitOfWorkFactory : ITrainDescriberUnitOfWorkFactory
    {
        private readonly ITrainDescriberContextFactory _contextFactory;

        public TrainDescriberUnitOfWorkFactory(ITrainDescriberContextFactory contextFactory)
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
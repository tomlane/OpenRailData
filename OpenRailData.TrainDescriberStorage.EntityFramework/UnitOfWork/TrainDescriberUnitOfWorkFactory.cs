using System;
using Microsoft.Extensions.Options;

namespace OpenRailData.TrainDescriberStorage.EntityFramework.UnitOfWork
{
    public class TrainDescriberUnitOfWorkFactory : ITrainDescriberUnitOfWorkFactory
    {
        private readonly ITrainDescriberContextFactory _contextFactory;
        private readonly IOptions<TrainDescriberContextOptions> _options;

        public TrainDescriberUnitOfWorkFactory(ITrainDescriberContextFactory contextFactory, IOptions<TrainDescriberContextOptions> options)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            _contextFactory = contextFactory;
            _options = options;
        }

        public ITrainDescriberUnitOfWork Create()
        {
            return new TrainDescriberUnitOfWork(_contextFactory.Create(_options));
        }
    }
}
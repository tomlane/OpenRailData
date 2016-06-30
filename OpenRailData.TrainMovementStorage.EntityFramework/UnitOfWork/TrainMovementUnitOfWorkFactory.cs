using System;
using Microsoft.Extensions.Options;

namespace OpenRailData.TrainMovementStorage.EntityFramework.UnitOfWork
{
    public class TrainMovementUnitOfWorkFactory : ITrainMovementUnitOfWorkFactory
    {
        private readonly ITrainMovementContextFactory _contextFactory;
        private readonly IOptions<TrainMovementContextOptions> _options;

        public TrainMovementUnitOfWorkFactory(ITrainMovementContextFactory contextFactory, IOptions<TrainMovementContextOptions> options)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            _contextFactory = contextFactory;
            _options = options;
        }

        public ITrainMovementUnitOfWork Create()
        {
            return new TrainMovementUnitOfWork(_contextFactory.Create(_options));
        }
    }
}
using System;
using OpenRailData.Configuration;

namespace OpenRailData.TrainMovementStorage.EntityFramework
{
    public class TrainMovementDatabase : ITrainMovementDatabase
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        private ITrainMovementContext _context;

        public ITrainMovementContext DbContext
        {
            get
            {
                if (_context == null)
                    _context = BuildContext();
                return _context;
            }
            set { _context = value; }
        }

        public TrainMovementDatabase(IConnectionStringProvider provider)
        {
            if (provider == null)
                throw new ArgumentNullException(nameof(provider));

            _connectionStringProvider = provider;
        }

        public ITrainMovementContext BuildContext()
        {
            return new TrainMovementContext(_connectionStringProvider);
        }
    }
}
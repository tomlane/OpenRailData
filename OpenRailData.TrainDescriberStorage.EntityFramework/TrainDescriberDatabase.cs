using System;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.TrainDescriberStorage.EntityFramework
{
    public class TrainDescriberDatabase : ITrainDescriberDatabase
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        private ITrainDescriberContext _context;

        public ITrainDescriberContext DbContext
        {
            get
            {
                if (_context == null)
                    _context = BuildContext();
                return _context;
            }
            set { _context = value; }
        }

        public TrainDescriberDatabase(IConnectionStringProvider provider)
        {
            if (provider == null)
                throw new ArgumentNullException(nameof(provider));

            _connectionStringProvider = provider;
        }

        public ITrainDescriberContext BuildContext()
        {
            return new TrainDescriberContext(_connectionStringProvider);
        }
    }
}
using System;
using System.Configuration;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.Schedule.NetworkRailScheduleDatabase
{
    public class ScheduleDatabase : IScheduleDatabase
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        private IScheduleContext _context;
        private readonly string _scheduleConnectionKey = ConfigurationManager.AppSettings["ScheduleConnectionKey"];

        public IScheduleContext DbContext
        {
            get
            {
                if (_context == null)
                    _context = BuildContext();
                return _context;
            }
            set { _context = value; }
        }

        public ScheduleDatabase(IConnectionStringProvider provider)
        {
            if (provider == null)
                throw new ArgumentNullException(nameof(provider));

            _connectionStringProvider = provider;

            //ensure sql provider available
            var x = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public IScheduleContext BuildContext()
        {
            return new ScheduleContext(_connectionStringProvider.ConnectionString(_scheduleConnectionKey));
        }
    }
}
using System;
using Microsoft.EntityFrameworkCore;

namespace OpenRailData.ScheduleStorage.EntityFramework
{
    public interface IScheduleDatabaseMigrator
    {
        void MigrateDatabase();
    }

    public class ScheduleDatabaseMigrator : IScheduleDatabaseMigrator
    {
        private readonly ScheduleContext _context;

        public ScheduleDatabaseMigrator(IScheduleContextFactory contextFactory)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));

            _context = contextFactory.Create();
        }
        public void MigrateDatabase()
        {
            _context.Database.Migrate();
        }
    }
}
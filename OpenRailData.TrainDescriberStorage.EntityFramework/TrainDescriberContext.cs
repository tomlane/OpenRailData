using System;
using Microsoft.EntityFrameworkCore;
using OpenRailData.Schedule.CommonDatabase;
using OpenRailData.TrainDescriberStorage.EntityFramework.Entities;

namespace OpenRailData.TrainDescriberStorage.EntityFramework
{
    public class TrainDescriberContext : ContextBase, ITrainDescriberContext
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public TrainDescriberContext(IConnectionStringProvider connectionStringProvider)
        {
            if (connectionStringProvider == null)
                throw new ArgumentNullException(nameof(connectionStringProvider));

            _connectionStringProvider = connectionStringProvider;
        }

        public DbSet<BerthMessageEntity> BerthMessages { get; set; }
        public DbSet<SignalMessageEntity> SignalMessages { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            const string schema = "TrainDescriber";
            
            //setting table names
            modelBuilder.Entity<BerthMessageEntity>().ToTable("BerthMessage", schema);
            modelBuilder.Entity<SignalMessageEntity>().ToTable("SignalMessage", schema);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStringProvider.ConnectionString("TrainDescriberContext"));
        }
    }

}

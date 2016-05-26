using System;
using Microsoft.EntityFrameworkCore;
using OpenRailData.Schedule.CommonDatabase;
using OpenRailData.TrainMovementStorage.EntityFramework.Entites;

namespace OpenRailData.TrainMovementStorage.EntityFramework
{
    public class TrainMovementContext : ContextBase, ITrainMovementContext
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public TrainMovementContext(IConnectionStringProvider connectionStringProvider)
        {
            if (connectionStringProvider == null)
                throw new ArgumentNullException(nameof(connectionStringProvider));

            _connectionStringProvider = connectionStringProvider;
        }

        public DbSet<TrainActivationEntity> TrainActivations { get; set; }
        public DbSet<TrainCancellationEntity> TrainCancellations { get; set; }
        public DbSet<TrainMovementEntity> TrainMovements { get; set; }
        public DbSet<TrainReinstatementEntity> TrainReinstatements { get; set; }
        public DbSet<ChangeOfOriginEntity> ChangeOfOrigins { get; set; }
        public DbSet<ChangeOfIdentityEntity> ChangeOfIdentities { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            const string schema = "TrainMovements";
            
            //setting table names
            modelBuilder.Entity<TrainActivationEntity>().ToTable("TrainActivation", schema);
            modelBuilder.Entity<TrainCancellationEntity>().ToTable("TrainCancellation", schema);
            modelBuilder.Entity<TrainMovementEntity>().ToTable("TrainMovement", schema);
            modelBuilder.Entity<TrainReinstatementEntity>().ToTable("TrainReinstatement", schema);
            modelBuilder.Entity<ChangeOfOriginEntity>().ToTable("ChangeOfOrigin", schema);
            modelBuilder.Entity<ChangeOfIdentityEntity>().ToTable("ChangeOfIdentity", schema);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStringProvider.ConnectionString("TrainMovementContext"));
        }
    }

}

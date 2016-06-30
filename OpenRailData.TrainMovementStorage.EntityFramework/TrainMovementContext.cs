using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenRailData.TrainMovementStorage.EntityFramework.Entities;

namespace OpenRailData.TrainMovementStorage.EntityFramework
{
    public class TrainMovementContext : DbContext, ITrainMovementContext
    {

        public TrainMovementContext(DbContextOptions options)
            : base(options)
        { }

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

        public DbSet<T> GetSet<T>() where T : class
        {
            return Set<T>();
        }

        public int SaveChanges()
        {
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}

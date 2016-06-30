using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OpenRailData.ScheduleStorage.EntityFramework.Entities;

namespace OpenRailData.ScheduleStorage.EntityFramework
{
    public class ScheduleContext : DbContext, IScheduleContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options)
            : base(options)
        { }

        public DbSet<HeaderRecordEntity> HeaderRecords { get; set; }
        public DbSet<AssociationRecordEntity> AssociationRecords { get; set; }
        public DbSet<TiplocRecordEntity> TiplocRecords { get; set; }
        public DbSet<ScheduleRecordEntity> ScheduleRecords { get; set; }
        public DbSet<ScheduleLocationRecordEntity> ScheduleLocationRecords { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            const string schema = "Schedule";
            
            //setting table names
            modelBuilder.Entity<HeaderRecordEntity>().ToTable("Header", schema);
            modelBuilder.Entity<AssociationRecordEntity>().ToTable("Association", schema);
            modelBuilder.Entity<TiplocRecordEntity>().ToTable("Tiploc", schema);
            modelBuilder.Entity<ScheduleRecordEntity>().ToTable("Record", schema);
            modelBuilder.Entity<ScheduleLocationRecordEntity>().ToTable("Location", schema);

            //setting cascade delete on schedule record locations
            modelBuilder.Entity<ScheduleRecordEntity>()
                .HasMany(x => x.ScheduleLocations)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
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

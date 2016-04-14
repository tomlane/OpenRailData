using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework
{
    public class ScheduleContext : ContextBase, IScheduleContext
    {
        public DbSet<HeaderRecordEntity> HeaderRecords { get; set; }
        public DbSet<AssociationRecordEntity> AssociationRecords { get; set; }
        public DbSet<TiplocRecordEntity> TiplocRecords { get; set; }
        public DbSet<ScheduleRecordEntity> ScheduleRecords { get; set; }
        public DbSet<ScheduleLocationRecordEntity> ScheduleLocationRecords { get; set; }
        
        public ScheduleContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer(new NullDatabaseInitializer<ScheduleContext>());
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            const string schema = "Schedule";

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //setting table names
            modelBuilder.Entity<HeaderRecordEntity>().ToTable("Header", schema);
            modelBuilder.Entity<AssociationRecordEntity>().ToTable("Association", schema);
            modelBuilder.Entity<TiplocRecordEntity>().ToTable("Tiploc", schema);
            modelBuilder.Entity<ScheduleRecordEntity>().ToTable("Record", schema);
            modelBuilder.Entity<ScheduleLocationRecordEntity>().ToTable("Location", schema);

            //setting cascade delete on schedule record locations
            modelBuilder.Entity<ScheduleRecordEntity>()
                .HasMany(r => r.ScheduleLocations)
                .WithOptional()
                .WillCascadeOnDelete(true);
        }
    }

}

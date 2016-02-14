using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using OpenRailData.Schedule.CommonDatabase;
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleDatabase
{
    public class ScheduleContext : ContextBase, IScheduleContext
    {
        public DbSet<HeaderRecord> HeaderRecords { get; set; }
        public DbSet<AssociationRecord> AssociationRecords { get; set; }
        public DbSet<TiplocRecord> TiplocRecords { get; set; }
        public DbSet<ScheduleRecord> ScheduleRecords { get; set; }
        public DbSet<ScheduleLocationRecord> ScheduleLocationRecords { get; set; }
        
        public ScheduleContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<ScheduleContext>(new NullDatabaseInitializer<ScheduleContext>());
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            const string schema = "Schedule";

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //setting table names
            modelBuilder.Entity<HeaderRecord>().ToTable("Header", schema);
            modelBuilder.Entity<AssociationRecord>().ToTable("Association", schema);
            modelBuilder.Entity<TiplocRecord>().ToTable("Tiploc", schema);
            modelBuilder.Entity<ScheduleRecord>().ToTable("Record", schema);
            modelBuilder.Entity<ScheduleLocationRecord>().ToTable("Location", schema);
        }
    }

}

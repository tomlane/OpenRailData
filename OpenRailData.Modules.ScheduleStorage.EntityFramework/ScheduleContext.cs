using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OpenRailData.Modules.ScheduleStorage.EntityFramework.Entities;
using OpenRailData.Schedule.CommonDatabase;

namespace OpenRailData.Modules.ScheduleStorage.EntityFramework
{
    public class ScheduleContext : ContextBase, IScheduleContext
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public ScheduleContext(IConnectionStringProvider connectionStringProvider)
        {
            if (connectionStringProvider == null)
                throw new ArgumentNullException(nameof(connectionStringProvider));

            _connectionStringProvider = connectionStringProvider;
        }

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStringProvider.ConnectionString("ScheduleContext"));
        }
    }

}

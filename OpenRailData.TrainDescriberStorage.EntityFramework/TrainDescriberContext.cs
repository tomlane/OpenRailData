using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenRailData.TrainDescriberStorage.EntityFramework.Entities;

namespace OpenRailData.TrainDescriberStorage.EntityFramework
{
    public class TrainDescriberContext : DbContext, ITrainDescriberContext
    {
        public TrainDescriberContext(DbContextOptions<TrainDescriberContext> options)
            : base(options)
        { }

        public DbSet<BerthMessageEntity> BerthMessages { get; set; }
        public DbSet<SignalMessageEntity> SignalMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            const string schema = "TrainDescriber";

            //setting table names
            modelBuilder.Entity<BerthMessageEntity>().ToTable("BerthMessage", schema);
            modelBuilder.Entity<SignalMessageEntity>().ToTable("SignalMessage", schema);
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

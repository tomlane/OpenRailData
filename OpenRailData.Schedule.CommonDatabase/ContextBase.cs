using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OpenRailData.Schedule.CommonDatabase
{
    public abstract class ContextBase : DbContext, IContext
    {
        public DbSet<T> GetSet<T>() where T : class
        {
            return Set<T>();
        }
        
        public IDbEntityEntryWrapper WrappedEntry(object entity)
        {
            return new DbEntityEntryWrapper(Entry(entity));
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}

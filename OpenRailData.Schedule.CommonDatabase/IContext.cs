using Microsoft.EntityFrameworkCore;

namespace OpenRailData.Schedule.CommonDatabase
{
    public interface IContext
    {
        DbSet<T> GetSet<T>() where T : class;

        IDbEntityEntryWrapper WrappedEntry(object entity);

        int SaveChanges();
    }
}

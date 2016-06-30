using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OpenRailData.CommonDatabase
{
    public interface IContext
    {
        DbSet<T> GetSet<T>() where T : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}

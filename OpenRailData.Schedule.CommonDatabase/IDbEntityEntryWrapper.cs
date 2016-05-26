using Microsoft.EntityFrameworkCore;

namespace OpenRailData.Schedule.CommonDatabase
{
    public interface IDbEntityEntryWrapper
    {
        EntityState State { get; set; }
    }
}

using System.Data.Entity;

namespace OpenRailData.Schedule.CommonDatabase
{
    public interface IDbEntityEntryWrapper
    {
        EntityState State { get; set; }
    }
}

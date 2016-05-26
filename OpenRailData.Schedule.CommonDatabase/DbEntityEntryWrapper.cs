using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace OpenRailData.Schedule.CommonDatabase
{
    public class DbEntityEntryWrapper : IDbEntityEntryWrapper
    {
        public EntityEntry EntityEntry { get; set; }

        public EntityState State
        {
            get
            {
                return EntityEntry.State;
            }
            set
            {
                EntityEntry.State = value;
            }
        }

        public DbEntityEntryWrapper(EntityEntry entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            EntityEntry = entity;
        }
    }
}

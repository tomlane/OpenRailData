﻿using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace OpenRailData.Schedule.CommonDatabase
{
    public class DbEntityEntryWrapper : IDbEntityEntryWrapper
    {
        public DbEntityEntry EntityEntry { get; set; }

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

        public DbEntityEntryWrapper(DbEntityEntry entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            EntityEntry = entity;
        }
    }
}

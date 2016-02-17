using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OpenRailData.Schedule.NetworkRailEntites.Records;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public class BaseRepository<TEntity> where TEntity : class, IIdentifyable
    {
        private readonly IScheduleContext _context;

        protected BaseRepository(IScheduleContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        protected void Add(TEntity entity)
        {
            _context.GetSet<TEntity>().Add(entity);
        }

        protected void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _context.GetSet<TEntity>().Add(entity);
            }
        }

        protected void Remove(TEntity entity)
        {
            _context.GetSet<TEntity>().Remove(entity);
        }

        protected void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _context.GetSet<TEntity>().Remove(entity);
            }
        }

        protected TEntity Get(int id)
        {
            return _context.GetSet<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        protected IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.GetSet<TEntity>().Where(predicate).ToList();
        }
    }
}
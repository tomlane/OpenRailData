using System;
using System.Data.Entity.Infrastructure;
using OpenRailData.Schedule.NetworkRailScheduleDatabase;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public class ScheduleUnitOfWork : IScheduleUnitOfWork
    {
        private readonly IScheduleContext _context;

        public ScheduleUnitOfWork(IDbContextFactory<ScheduleContext> contextFactory)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));

            _context = contextFactory.Create();

            HeaderRecords = new HeaderRecordRepository(_context);
            TiplocRecords = new TiplocRecordRepository(_context);
            AssociationRecords = new AssociationRecordRepository(_context);
            ScheduleRecords = new ScheduleRecordRepository(_context);
            ScheduleLocationRecords = new ScheduleLocationRecordRepository(_context);
        }

        public IHeaderRecordRepository HeaderRecords { get; }
        public ITiplocRecordRepository TiplocRecords { get; }
        public IAssociationRecordRepository AssociationRecords { get; }
        public IScheduleRecordRepository ScheduleRecords { get; }
        public IScheduleLocationRecordRepository ScheduleLocationRecords { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose() => _context?.Dispose();
    }
}
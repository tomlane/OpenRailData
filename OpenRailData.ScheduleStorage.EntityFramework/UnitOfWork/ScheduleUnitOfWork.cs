using System;
using System.Threading.Tasks;
using OpenRailData.Schedule.ScheduleStorage;
using OpenRailData.ScheduleStorage.EntityFramework.Repository;

namespace OpenRailData.ScheduleStorage.EntityFramework.UnitOfWork
{
    public class ScheduleUnitOfWork : IScheduleUnitOfWork
    {
        private readonly IScheduleContext _context;

        public ScheduleUnitOfWork(IScheduleContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;

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

        public async Task<int> Complete() => await _context.SaveChangesAsync();

        public void Dispose() => _context?.Dispose();
    }
}
using System;
using System.Threading.Tasks;

namespace OpenRailData.ScheduleStorage
{
    public interface IScheduleUnitOfWork : IDisposable
    {
        IHeaderRecordRepository HeaderRecords { get; }
        ITiplocRecordRepository TiplocRecords { get; }
        IAssociationRecordRepository AssociationRecords { get; }
        IScheduleRecordRepository ScheduleRecords { get; }
        IScheduleLocationRecordRepository ScheduleLocationRecords { get; }

        Task<int> Complete();
    }
}
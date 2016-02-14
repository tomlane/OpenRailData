using System;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public interface IScheduleUnitOfWork : IDisposable
    {
        IHeaderRecordRepository HeaderRecords { get; }
        ITiplocRecordRepository TiplocRecords { get; }
        IAssociationRecordRepository AssociationRecords { get; }
        IScheduleRecordRepository ScheduleRecords { get; }
        IScheduleLocationRecordRepository ScheduleLocationRecords { get; }

        int Complete();
    }
}
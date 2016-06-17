using System;
using System.Threading.Tasks;
using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.Schedule
{
    public interface IScheduleProvider
    {
        Task<ScheduleRecord> GetScheduleRecord(string trainUid, DateTime startDate);
    }
}
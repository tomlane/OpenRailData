using System;
using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule
{
    public interface IScheduleProvider
    {
        Task<ScheduleRecord> GetScheduleRecord(string trainUid, DateTime startDate);
    }
}
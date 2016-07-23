using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleStorage
{
    public interface IScheduleRecordRepository
    {
        Task InsertRecord(ScheduleRecord record);
        Task InsertMultipleRecords(IEnumerable<ScheduleRecord> records);
        Task AmendRecord(ScheduleRecord record);
        Task DeleteRecord(ScheduleRecord record);

        Task<List<ScheduleRecord>> GetScheduleRecords(string trainUid, DateTime startDate);
    }
}
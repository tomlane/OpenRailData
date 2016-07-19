using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleStorage
{
    public interface IScheduleRecordRepository
    {
        void InsertRecord(ScheduleRecord record);
        void AmendRecord(ScheduleRecord record);
        void DeleteRecord(ScheduleRecord record);

        Task InsertRecordAsync(ScheduleRecord record);
        Task InsertMultipleRecordsAsync(IEnumerable<ScheduleRecord> records);
        Task AmendRecordAsync(ScheduleRecord record);
        Task DeleteRecordAsync(ScheduleRecord record);

        Task<IEnumerable<ScheduleRecord>> GetScheduleRecords(string trainUid, DateTime startDate);
    }
}
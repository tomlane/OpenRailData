using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleStorage
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
    }
}
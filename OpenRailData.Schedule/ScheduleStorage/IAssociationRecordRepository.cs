using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleStorage
{
    public interface IAssociationRecordRepository
    {
        void InsertRecord(AssociationRecord record);
        void AmendRecord(AssociationRecord record);
        void DeleteRecord(AssociationRecord record);

        Task InsertRecordAsync(AssociationRecord record);
        Task InsertMultipleRecordsAsync(IEnumerable<AssociationRecord> records);
        Task AmendRecordAsync(AssociationRecord record);
        Task DeleteRecordAsync(AssociationRecord record);
    }
}
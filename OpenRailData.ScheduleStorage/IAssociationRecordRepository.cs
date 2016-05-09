using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleStorage
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
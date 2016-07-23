using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Schedule.Entities;

namespace OpenRailData.Schedule.ScheduleStorage
{
    public interface IAssociationRecordRepository
    {
        Task InsertRecord(AssociationRecord record);
        Task InsertMultipleRecords(IEnumerable<AssociationRecord> records);
        Task AmendRecord(AssociationRecord record);
        Task DeleteRecord(AssociationRecord record);
    }
}
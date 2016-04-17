using OpenRailData.Domain.ScheduleRecords;

namespace OpenRailData.ScheduleStorage
{
    public interface IAssociationRecordRepository
    {
        void InsertRecord(AssociationRecord record);

        void AmendRecord(AssociationRecord record);

        void DeleteRecord(AssociationRecord record);
    }
}
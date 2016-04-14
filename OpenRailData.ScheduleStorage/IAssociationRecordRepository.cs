using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.ScheduleStorage
{
    public interface IAssociationRecordRepository
    {
        void InsertRecord(AssociationRecord record);

        void AmendRecord(AssociationRecord record);

        void DeleteRecord(AssociationRecord record);
    }
}
using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.DataAccess.Core
{
    public interface IAssociationRecordRepository
    {
        void InsertRecord(AssociationRecord record);

        void AmendRecord(AssociationRecord record);

        void DeleteRecord(AssociationRecord record);
    }
}
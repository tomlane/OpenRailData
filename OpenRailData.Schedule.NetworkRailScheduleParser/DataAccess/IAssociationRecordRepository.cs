using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public interface IAssociationRecordRepository
    {
        void InsertRecord(AssociationRecord record);

        void AmendRecord(AssociationRecord record);

        void DeleteRecord(AssociationRecord record);
    }
}
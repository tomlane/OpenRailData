using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public interface ITiplocRecordRepository
    {
        void InsertRecord(TiplocRecord record);

        void AmendRecord(TiplocRecord record);

        void DeleteRecord(TiplocRecord record);

        void AmendLocationName(string locationName, string tiplocCode);
    }
}
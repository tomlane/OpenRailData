using OpenRailData.Schedule.NetworkRailEntites.Records;

namespace OpenRailData.Schedule.NetworkRailScheduleParser.DataAccess
{
    public interface ITiplocRecordRepository : IBaseRepository<TiplocRecord>
    {
        void InsertRecord(TiplocRecord record);

        void AmendRecord(TiplocRecord newRecord);

        void DeleteRecord(TiplocRecord record);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementStorage
{
    public interface IChangeOfOriginRepository
    {
        void InsertRecord(ChangeOfOrigin record);
        void AmendRecord(ChangeOfOrigin record);
        void DeleteRecord(ChangeOfOrigin record);

        Task InsertRecordAsync(ChangeOfOrigin record);
        Task InsertMultipleRecordsAsync(IEnumerable<ChangeOfOrigin> records);
        Task AmendRecordAsync(ChangeOfOrigin record);
        Task DeleteRecordAsync(ChangeOfOrigin record);
    }
}
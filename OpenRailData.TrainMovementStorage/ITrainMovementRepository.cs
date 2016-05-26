using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementStorage
{
    public interface ITrainMovementRepository
    {
        void InsertRecord(TrainMovement record);
        void AmendRecord(TrainMovement record);
        void DeleteRecord(TrainMovement record);

        Task InsertRecordAsync(TrainMovement record);
        Task InsertMultipleRecordsAsync(IEnumerable<TrainMovement> records);
        Task AmendRecordAsync(TrainMovement record);
        Task DeleteRecordAsync(TrainMovement record);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementStorage
{
    public interface ITrainReinstatementRepository
    {
        void InsertRecord(TrainReinstatement record);
        void AmendRecord(TrainReinstatement record);
        void DeleteRecord(TrainReinstatement record);

        Task InsertRecordAsync(TrainReinstatement record);
        Task InsertMultipleRecordsAsync(IEnumerable<TrainReinstatement> records);
        Task AmendRecordAsync(TrainReinstatement record);
        Task DeleteRecordAsync(TrainReinstatement record);
    }
}
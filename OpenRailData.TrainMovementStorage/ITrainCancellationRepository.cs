using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementStorage
{
    public interface ITrainCancellationRepository
    {
        void InsertRecord(TrainCancellation record);
        void AmendRecord(TrainCancellation record);
        void DeleteRecord(TrainCancellation record);

        Task InsertRecordAsync(TrainCancellation record);
        Task InsertMultipleRecordsAsync(IEnumerable<TrainCancellation> records);
        Task AmendRecordAsync(TrainCancellation record);
        Task DeleteRecordAsync(TrainCancellation record);
    }
}
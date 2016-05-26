using System.Collections.Generic;
using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementStorage
{
    public interface ITrainActivationRepository
    {
        void InsertRecord(TrainActivation record);
        void AmendRecord(TrainActivation record);
        void DeleteRecord(TrainActivation record);

        Task InsertRecordAsync(TrainActivation record);
        Task InsertMultipleRecordsAsync(IEnumerable<TrainActivation> records);
        Task AmendRecordAsync(TrainActivation record);
        Task DeleteRecordAsync(TrainActivation record);
    }
}
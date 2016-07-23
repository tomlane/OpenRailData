using System.Threading.Tasks;
using OpenRailData.TrainMovement.Entities;

namespace OpenRailData.TrainMovement.TrainMovementStorage
{
    public interface ITrainMovementRepository<T> where T : ITrainMovementMessage
    {
        Task InsertRecord(T record);
        Task AmendRecord(T record);
        Task DeleteRecord(T record);
    }
}
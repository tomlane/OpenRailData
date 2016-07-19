using System.Threading.Tasks;
using OpenRailData.TrainMovement.Entities;

namespace OpenRailData.TrainMovement.TrainMovementStorage
{
    public interface ITrainMovementStorageProcessor
    {
        TrainMovementMessageType MessageType { get; }

        Task ProcessMessage(ITrainMovementMessage message);
    }
}
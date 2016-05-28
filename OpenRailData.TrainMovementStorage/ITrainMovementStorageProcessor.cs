using System.Threading.Tasks;
using OpenRailData.Domain.TrainMovements;

namespace OpenRailData.TrainMovementStorage
{
    public interface ITrainMovementStorageProcessor
    {
        TrainMovementMessageType MessageType { get; }

        Task ProcessMessage(ITrainMovementMessage message);
    }
}
using System.Threading.Tasks;
using OpenRailData.TrainMovement.Entities;

namespace OpenRailData.MessageProcessing
{
    public interface ITrainMovementMessageProcessor
    {
        TrainMovementMessageType MessageType { get; }

        Task ProcessMessage(ITrainMovementMessage message);
    }
}